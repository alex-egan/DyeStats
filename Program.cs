global using LiteDB;
global using System.Linq;
global using DyeStats.Services.GameService;
global using DyeStats.Classes;
global using DyeStats.Services.PlayService;
global using DyeStats.Services.PlayerService;
global using DyeStats.Services.LiteDBService;
global using DyeStats.Services.LocationService;
global using DyeStats.Services.LogService;
global using DyeStats.Services.PlayTypeService;
using DyeStats.Data;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMudServices();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddTransient<ILiteDBService, LiteDBService>();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IPlayService, PlayService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPlayTypeService, PlayTypeService>();
builder.Services.AddSingleton<WeatherForecastService>();

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
