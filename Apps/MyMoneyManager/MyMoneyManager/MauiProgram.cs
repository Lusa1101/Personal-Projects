﻿using Microsoft.Extensions.Logging;

namespace MyMoneyManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            //For the SQLite local database
            string dbPath = FileAccessHelper.GetLocalFilePath("moneymanager.db3");

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //For the SQLite local database
            builder.Services.AddSingleton<Repository>(s => ActivatorUtilities.CreateInstance<Repository>(s, dbPath));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
