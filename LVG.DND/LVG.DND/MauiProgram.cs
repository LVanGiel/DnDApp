using CommunityToolkit.Maui;
using LVG.DND.Models;
using LVG.DND.Pages;
using LVG.DND.ViewModel;

namespace LVG.DND;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<DndDice>();
        builder.Services.AddTransient<DndDiceViewModel>();
        builder.Services.AddTransient<CharacterCollection>();
        builder.Services.AddSingleton<ClassSelectorViewModel>();

        return builder.Build();
	}
}
