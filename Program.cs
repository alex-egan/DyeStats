global using LiteDB;
global using System.Linq;
using DyeStats.Data;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DyeStats.Services.GameService;
using DyeStats.Services.PlayService;
using DyeStats.Services.PlayerService;
using DyeStats.Services.LiteDBService;
using DyeStats.Services.LocationService;
using DyeStats.Services.LogService;
using DyeStats.Services.PlayTypeService;

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
