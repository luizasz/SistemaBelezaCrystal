using SistemaBelezaCrystal.Components;
using SistemaBelezaCrystal.Models;
using SistemaBelezaCrystal.Config;
using AppExemplo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<Conexao>();
builder.Services.AddScoped<FornecedorDAO>();
builder.Services.AddScoped<FuncionarioDAO>();
builder.Services.AddScoped<ProdutoDAO>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
