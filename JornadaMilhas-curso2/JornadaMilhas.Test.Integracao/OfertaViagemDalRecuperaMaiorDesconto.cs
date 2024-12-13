﻿using Bogus;
using JornadaMilhas.Dados;
using JornadaMilhasV1.Gerenciador;
using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemDalRecuperaMaiorDesconto
{
    private readonly JornadaMilhasContext _context;
    private readonly ContextoFixture _contextoFixture;
    public OfertaViagemDalRecuperaMaiorDesconto(ContextoFixture contextoFixture)
    {
            _context = contextoFixture.Context;
            this._contextoFixture = contextoFixture;
    }


    [Fact]
    // destino = são paulo, desconto = 40, preco = 80
    public void RetornaOfertaEspecificaQuandoDestinoSaoPauloEDesconto40()
    {
        //arrange
        var rota = new Rota("Curitiba", "São Paulo");
        Periodo periodo = new PeriodoDataBuilder() { DataInicial = new DateTime(2024,5,20)}.Build();
        _contextoFixture.CriaDadosFake();

        var ofertaEscolhida = new OfertaViagem(rota, periodo, 80)
        {
            Desconto = 40,
            Ativa = true
        };

        var dal = new OfertaViagemDAL(_context);
        dal.Adicionar(ofertaEscolhida);

        Func<OfertaViagem, bool> filtro = o => o.Rota.Destino.Equals("São Paulo");
        var precoEsperado = 40;

        //act
        var oferta = dal.RecuperaMaiorDesconto(filtro);

        //assert
        Assert.NotNull(oferta);
        Assert.Equal(precoEsperado, oferta.Preco, 0.0001);
    }
}
