using JornadaMilhas.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemDalRecuperarTodas
{
    private readonly JornadaMilhasContext context;

    public OfertaViagemDalRecuperarTodas(ITestOutputHelper outputHelper, ContextoFixture contextoFixture)
    {
        context = contextoFixture.Context;
        outputHelper.WriteLine(context.GetHashCode().ToString());
    }

    [Fact]
    public void RetornaNTodasAsOfertasDeViageme()
    {
        //arrange
        var dal = new OfertaViagemDAL(context);

        //act
        var ofertaRecuperada = dal.RecuperarTodas();

        //assert
        Assert.NotNull(ofertaRecuperada);
    }
}
