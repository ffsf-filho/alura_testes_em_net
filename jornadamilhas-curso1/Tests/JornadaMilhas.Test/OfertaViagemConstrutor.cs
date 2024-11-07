using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemConstrutor
{
    [Theory]
    [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
    [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)]
    [InlineData(null, "S�o Paulo", "2024-01-01", "2024-01-02", -1, false)]
    [InlineData("Vit�ria", "S�o Paulo", "2024-01-01", "2024-01-01", 0, false)]
    [InlineData("Rio de Janeiro", "S�o Paulo", "2024-01-01", "2024-01-02", -500, false)]
    public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
    {
        //cenario - arrange
        Rota rota = new Rota(origem, destino);
        Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

        //A��o - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //Teste -assert
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroRotaOuPeriodoInvalidosQuandoRotaNula()
    {
        //Cenario - arrange
        Rota rota =null;
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;

        //A��o - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //Teste - assert
        Assert.Contains("A oferta de viagem n�o possui rota ou per�odo v�lidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroEOfertaInvalidaQuandoOPeriodoInvalido()
    {
        //Cenario - arrange
        Rota rota = new Rota("OrigemTeste", "DestinoTeste"); ;
        Periodo periodo = new Periodo(new DateTime(2024, 3, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;

        //A��o - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //Teste - assert
        Assert.Contains("Erro: Data de ida n�o pode ser maior que a data de volta.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-250)]
    public void RetornaMensagemDeErroInvalidoQuandoPrecoMenorOuIgualAZero(double preco)
    {
        //arrange
        Rota rota = new Rota("Origem1", "Destino1");
        Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));

        //act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //assert
        Assert.Contains( "O pre�o da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
    }
}