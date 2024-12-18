﻿using JornadaMilhas.Dominio.Entidades;
using JornadaMilhas.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Integration.Test.API;

public class OfertaViagem_POST: IClassFixture<JornadaMilhasWebApplicationFactory>
{
    private readonly JornadaMilhasWebApplicationFactory _app;

    public OfertaViagem_POST(JornadaMilhasWebApplicationFactory app)
    {
        _app = app;
    }

    [Fact]
    public async Task Cadastra_OfertaViagem()
    {
        //arrange
        using var client = await _app.GetClientWithAccessTokenAsync();

        var ofertaViagem = new OfertaViagem()
        {
            Preco = 100,
            Rota = new Rota("Origem", "Destino"),
            Periodo = new Periodo(DateTime.Parse("2024-03-03"), DateTime.Parse("2024-03-06"))
        };

        //act
        var response = await client.PostAsJsonAsync("/ofertas-viagem", ofertaViagem);

        //assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Cadastra_OfertaViagem_SemAutorizacao()
    {
        //arrange
        using var client = _app.CreateClient();

        var ofertaViagem = new OfertaViagem()
        {
            Preco = 100,
            Rota = new Rota("Origem", "Destino"),
            Periodo = new Periodo(DateTime.Parse("2024-03-03"), DateTime.Parse("2024-03-06"))
        };

        //act
        var response = await client.PostAsJsonAsync("/ofertas-viagem", ofertaViagem);

        //assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
