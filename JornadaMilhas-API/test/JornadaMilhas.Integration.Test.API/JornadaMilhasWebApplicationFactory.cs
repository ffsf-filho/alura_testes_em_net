﻿using JornadaMilhas.API.DTO.Auth;
using JornadaMilhas.Dados;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace JornadaMilhas.Integration.Test.API;

public class JornadaMilhasWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<JornadaMilhasContext>));
            services.AddDbContext<JornadaMilhasContext>(options =>
                options
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=localhost,1438;Database=JornadaMilhasV3;User Id=sa;Password=ssExpress1823;Encrypt=false;TrustServerCertificate=true;MultipleActiveResultSets=true;"));
        });

        base.ConfigureWebHost(builder);
    }

    public async Task<HttpClient> GetClientWithAccessTokenAsync()
    {
        var client = this.CreateClient();
        var user = new UserDTO { Email = "tester@email.com", Password = "Senha123@" };
        var resultado = await client.PostAsJsonAsync("/auth-login", user);
        resultado.EnsureSuccessStatusCode();
        var result = await resultado.Content.ReadFromJsonAsync<UserTokenDTO>();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result!.Token);
        return client;
    }
}
