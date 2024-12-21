using ScreenSound.Modelos;
using System.Net.Http.Json;

namespace ScreenSound.Integration.Test;

public class Artista_GET : IClassFixture<ScreenSoundWebApplicationFactory>
{
    private readonly ScreenSoundWebApplicationFactory _app;

    public Artista_GET(ScreenSoundWebApplicationFactory app)
    {
        _app = app;
    }

    [Fact]
    public async Task Recupera_Artista_Por_Nome()
    {
        //arrange
        var artistaExistente = _app.Context.Artistas.FirstOrDefault();

        if(artistaExistente is null)
        {
            artistaExistente = new Artista() 
            { 
                Nome = "João Silva",
                Bio = "Nascido em são Paulo"
            };

            _app.Context.Add(artistaExistente);
            _app.Context.SaveChanges();
        }

        using var client = _app.CreateClient();

        //act
        var response = await client.GetFromJsonAsync<Artista>("/Artistas/" + artistaExistente.Nome);

        //assert
        Assert.NotNull(response);
        Assert.Equal(artistaExistente.Id, response.Id);
        Assert.Equal(artistaExistente.Nome, response.Nome);
    }
}
