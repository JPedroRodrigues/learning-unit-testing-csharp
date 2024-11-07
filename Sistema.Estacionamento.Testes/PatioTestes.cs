using Xunit;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;

namespace Sistema.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = "Giovanni";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "abc-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            var faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        /// <summary>
        /// Theory permite passar uma representação de um
        /// objeto inline, por meio da anotação InlineData.
        /// </summary>
        [Theory]
        [InlineData("João", "ASD-1498", "preto", "Civic")]
        [InlineData("Sabrina", "POL-1498", "cinza", "Virtus")]
        [InlineData("Joanathan Santos", "GDR-1498", "azul", "Opala")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            var faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Joanathan Santos", "GDR-1498", "azul", "Opala")]
        public void LocalizaVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Placa = placa,
                Cor = cor,
                Modelo = modelo
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            // Act
            var consulta = estacionamento.PesquisaVeiculo(placa);

            // Assert
            Assert.Equal(placa, consulta.Placa);
        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            // Arrange
            var veiculo = new Veiculo
            {
                Proprietario = "Juan",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Verde",
                Modelo = "Fusca",
                Placa = "abc-9999"
            };

            var estacionamento = new Patio();
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAtualizado = new Veiculo
            {
                Proprietario = "Juan",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Prata", // Atualização
                Modelo = "Mustang", // Atualizado
                Placa = "abc-9999"
            };

            // Act
            var novoVeiculo = estacionamento.AtualizarVeiculo(veiculoAtualizado);

            // Assert
            Assert.Equal(novoVeiculo.Cor, veiculoAtualizado.Cor);
        }
    }
}
