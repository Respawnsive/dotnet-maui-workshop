using Apizr;
using Microsoft.Extensions.Logging;
using MonkeyFinder.Services;
using MonkeyFinder.View;

namespace MonkeyFinder;

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
#if DEBUG
		builder.Logging.AddDebug();
#endif

		// Plugins
    	builder.Services.AddSingleton(Connectivity.Current);
		builder.Services.AddSingleton(Geolocation.Default);
		builder.Services.AddSingleton(Map.Default);

        // Services
        builder.Services.AddApizrManagerFor<IMonkeyApi>();
        builder.Services.AddSingleton<IMonkeyService, MonkeyService>();

        // Presentation
        builder.Services.AddSingleton<MonkeysViewModel>();
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<MonkeyDetailsViewModel>();
		builder.Services.AddTransient<DetailsPage>();

		return builder.Build();
	}
}
