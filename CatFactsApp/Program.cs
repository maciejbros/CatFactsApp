using CatFactsApp.Services;
using CatFactsApp.Services.Interfaces;
using CatFactsApp.UI;
using Microsoft.Extensions.DependencyInjection;
using System;

var services = new ServiceCollection();

services.AddHttpClient<ICatFactService, CatFactService>();
services.AddSingleton<IFileService, FileService>();
services.AddSingleton<ConsoleUI>();

var serviceProvider = services.BuildServiceProvider();

var ui = serviceProvider.GetRequiredService<ConsoleUI>();

await ui.RunAsync();