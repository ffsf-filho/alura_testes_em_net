using ScreenSound.API.Requests;
using System.Net;
using System.Net.Http.Json;

namespace ScreenSound.Integration.Test;

public class Artista_POST: IClassFixture<ScreenSoundWebApplicationFactory>
{
    private readonly ScreenSoundWebApplicationFactory _app;

    public Artista_POST(ScreenSoundWebApplicationFactory app)
    {
        _app = app;
    }

    [Fact]
    public async Task Cadastra_Artista()
    {
        //arrange
        using var client = _app.CreateClient();
        var artista = new ArtistaRequest("João silva", "Nascido no Espírito Santo");

        //act
        var response = await client.PostAsJsonAsync("/Artistas", artista);

        //assert
        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
