using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OMS.Plugins.InMemory;
using OMS.UseCases.Lejere;
using OMS.UseCases.Lejere.Interfaces;
using OMS.UseCases.PluginInterfaces;
using OMS.WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// ILejerRepository implementeres her med LejerRepository og vil instatiere et objekt af LejerRepository klassen
// og give det til konstrukt�ren af use casen i 'this.lejerRepository' og give det videre til 'lejerRepository' feltet (private readonly)
builder.Services.AddSingleton<ILejerRepository, LejerRepository>();
builder.Services.AddTransient<IViewLejereByNameUseCase, ViewLejereByNameUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
