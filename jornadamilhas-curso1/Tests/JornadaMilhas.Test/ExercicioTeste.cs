using Bogus;
using JornadaMilhas.Test.Exercicio;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test;

public class ExercicioTeste
{
    [Theory]
    [InlineData("Música Teste")]
    [InlineData("Outra Música")]
    [InlineData("Mais uma Música")]
    [InlineData("Azul da cor do mar")]
    public void InicializaNomeCorretamenteQuandoCastradaNovaMusica(string nome)
    {
        //Act
        Musica musica = new Musica(nome);

        //Assert
        Assert.Equal(nome, musica.Nome);
    }

    [Theory]
    [InlineData("Música Teste", "Nome: Música Teste")]
    [InlineData("Outra Música", "Nome: Outra Música")]
    [InlineData("Mais uma Música", "Nome: Mais uma Música")]
    public void ExibeDadosDaMusicaCorretamenteQuandoChamadoMetodoExibeFichaTecnica(string nome, string saidaEsperada)
    {
        // Arrange
        Musica musica = new Musica(nome);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        musica.ExibirFichaTecnica();
        string saidaAtual = stringWriter.ToString().Trim();

        // Assert
        Assert.Equal(saidaEsperada, saidaAtual);
    }

    [Theory]
    [InlineData(1, "Música Teste", "Id: 1 Nome: Música Teste")]
    [InlineData(2, "Outra Música", "Id: 2 Nome: Outra Música")]
    [InlineData(3, "Mais uma Música", "Id: 3 Nome: Mais uma Música")]
    [InlineData(4, "Azul da cor do mar", "Id: 4 Nome: Azul da cor do mar")]
    public void ExibeDadosDaMusicaCorretamenteQuandoChamadoMetodoToString(int id, string nome, string toStringEsperado)
    {
        // Arrange
        Musica musica = new Musica(nome)
        {
            Id=id,
        };

        // Act
        string resultado = musica.ToString();

        // Assert
        Assert.Equal(toStringEsperado, resultado);
    }

    [Fact]
    public void RetornaAnoDeLancamentoNuloQuandoValorEhMenorQueZero()
    {
        // Arrange
        int anoInvalido = -1;
        Musica musica = new Musica("Nome");

        // Act
        musica.AnoLancamento = anoInvalido;

        // Assert
        Assert.Null(musica.AnoLancamento);
    }

    [Fact]
    public void RetornaArtistaDesconhecidoQuandoValorInseridoEhNulo()
    {
        // Arrange
        Musica musica = new Musica("Nome");

        // Act
        musica.Artista = null;

        // Assert
        Assert.Equal("Artista desconhecido", musica.Artista);
    }

    [Fact]
    public void RetornaToStringCorretamenteQuandoMusicaEhCadastrada()
    {
        // Arrange
        var faker = new Faker();
        var id = faker.Random.Int();
        var nome = faker.Music.Genre();
        var saidaEsperada = $"Id: {id} Nome: {nome}";
        var musica = new Musica(nome) { Id = id };

        // Act
        var result = musica.ToString();

        // Assert
        Assert.Equal(saidaEsperada, result);
    }

    [Fact]
    public void RetornaArtistaDesconhecidoQuandoInseridoDadoNuloNoArtista()
    {
        // Arrange
        var nome = new Faker().Music.Genre();
        var musica = new Musica(nome) { Artista = null };

        // Act
        var artista = musica.Artista;

        // Assert
        Assert.Equal("Artista desconhecido", artista);
    }

    [Fact]
    public void RetornoAnoDeLancamentoNuloQuandoValorInseridoMenorQueZero()
    {
        // Arrange
        var nome = new Faker().Music.Genre();
        var musica = new Musica(nome) { AnoLancamento = -1 };

        // Act
        var anoLancamento = musica.AnoLancamento;

        // Assert
        Assert.Null(anoLancamento);
    }
}
