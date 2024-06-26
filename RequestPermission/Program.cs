using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using RequestPermission.Base;
using RequestPermission.Components;
using RequestPermission.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7044/api/")
});

builder.Services.AddScoped<AuthorizationProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthorizationProvider>();
builder.Services.AddScoped<MainLayoutCascadingValue>();
builder.Services.AddAuthenticationCore();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredLocalStorage(/*config=>config.JsonSerializerOptions*/);

builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
