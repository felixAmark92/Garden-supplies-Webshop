using Labb2WebbTemplate.App;
using Labb2WebbTemplate.App.Components;
using Labb2WebbTemplate.App.Extensions;
using Labb2WebbTemplate.App.Services;
using Microsoft.JSInterop;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient("main", client =>
{
    client.BaseAddress = new Uri("http://localhost:5106");
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthentication();

builder.Services
    .AddMudServices()
    .AddAppServices()
;

builder.Services.AddScoped<JavascriptConsole>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app
    .UseAuthentication()
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();