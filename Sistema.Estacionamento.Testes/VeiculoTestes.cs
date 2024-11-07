namespace Sistema.Estacionamento.Testes;

using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

public class VeiculoTestes
{
    /// <summary>
    /// Dentro do fact, posso utilizar alguns parâmetros para tratar o meu teste
    /// Um deles, é o skip, que permite que o teste seja ignorado. Outro, é o
    /// DisplayName, que permite que um nome seja dado ao teste além do referente
    /// de seu método.
    /// A anotação Trait permite atribuir chave-valor ao teste, identificando-o
    /// em uma categoria
    /// </summary>
    [Fact(DisplayName = "Teste de Aceleração de Veículo")]
    [Trait("Funcionalidade", "Acelerar")]
    public void TestaVeiculoAcelerar()
    {
        // Padrão AAA
        
        // Arrange: realizar o setup para execução dos testes
        var veiculo = new Veiculo();
        
        // Act: realizar a ação, chamando o método a ser testado
        veiculo.Acelerar(10);
        
        // Assert: invocar o método e executar a validação
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact(DisplayName = "Teste de freio de veículo")]
    [Trait("Funcionalidade", "Frear")]
    public void TestaVeiculoFrear()
    {
        // Arrange
        var veiculo = new Veiculo();
        
        // Act
        veiculo.Frear(10);

        // Assert
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact(Skip = "Teste ainda não implementado")]
    public void ValidaNomeProprietario()
    {

    }

    [Theory]
    [ClassData(typeof(Veiculo))]
    public void TestaVeiculoClass(Veiculo modelo)
    {
        // Arrange
        var veiculo = new Veiculo();

        // Act
        veiculo.Acelerar(10);
        modelo.Acelerar(10);

        // Assert
        Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void DadosVeiculo()
    {
        // Arrange
        var carro = new Veiculo
        {
            Cor = "Cinza",
            Modelo = "Civic",
            Placa = "ZAP-9999",
            Tipo = TipoVeiculo.Automovel,
            Proprietario = "Marcos Fernando",
        };

        // Act
        var dados = carro.ToString();

        // Assert
        Assert.Contains("Tipo do Veículo:", dados);
    }
}