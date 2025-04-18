﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using EndToEnd.Data;
namespace OctoCook;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        

        var dbPath =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                @"MyRecipes.db");
        builder.Services.AddSingleton<RecipeDataService>(
            s => ActivatorUtilities.CreateInstance<RecipeDataService>(s, dbPath));



        return builder.Build();
	}
}
