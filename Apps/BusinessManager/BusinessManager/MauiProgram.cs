using Microsoft.Extensions.Logging;
using CommunityToolkit;
using CommunityToolkit.Maui;
using BusinessManager.ViewModels;

namespace BusinessManager
{
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

            //Add the ViewModels
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton(new MainViewModel());

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
