using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemTeste
{
    [Fact]
    public void TestandoOfertaValida()
    {
        //cenario - arrange
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;
        var validacao = true;

        //Ação - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //Teste -assert
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void TestandoOfertaComRotaNula()
    {
        //Cenario - arrange
        Rota rota =null;
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;

        //Ação - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //Teste - assert
        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }

    [Fact]
    public void TestandoOfertaComPeriodoInvalido()
    {
        //Cenario - arrange
        Rota rota = new Rota("OrigemTeste", "DestinoTeste"); ;
        Periodo periodo = new Periodo(new DateTime(2024, 3, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;

        //Ação - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //Teste - assert
        Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }
}