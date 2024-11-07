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
}
