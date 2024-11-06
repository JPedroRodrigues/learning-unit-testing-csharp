namespace Sistema.Estacionamento.Testes;

using Alura.Estacionamento.Modelos;
using Xunit;

public class VeiculoTestes
{
    [Fact]
    public void TestaVeiculoAcelerar()
    {
        var veiculo = new Veiculo();
        veiculo.Acelerar(10);

        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFrear()
    {
        var veiculo = new Veiculo();
        veiculo.Frear(10);

        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }
}