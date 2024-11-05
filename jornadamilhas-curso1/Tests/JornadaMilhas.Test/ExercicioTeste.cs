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
    [Fact]
    public void TesteNomeInicializadoCorretamente()
    {
        //Arrange
        string nome = "Azul da cor do mar";

        //Act
        Musica musica = new Musica(nome);

        //Assert
        Assert.Equal(nome, musica.Nome);
    }

    [Fact]
    public void TesteIdInicializadoCorretamente()
    {
        //Arrange
        string nome = "Azul da cor do mar";
        int id = 1;

        //Act
        Musica musica = new Musica(nome) 
        {
            Id = id,
        };

        //Assert
        Assert.Equal(1, musica.Id);
    }

    [Fact]
    public void ValidaSaidaDoMetodoToString()
    {
        //Arrange
        string nome = "Azul da cor do mar";
        int id = 1;
        Musica musica = new Musica(nome)
        {
            Id = id,
        };
        string toStringEsperado = $"Id: {id} Nome: {nome}";

        //Act
        string resultado = musica.ToString();

        //Assert
        Assert.Equal(toStringEsperado, resultado);
    }
}
