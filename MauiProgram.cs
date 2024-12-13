﻿using CommunityToolkit.Maui;
using Controls.UserDialogs.Maui;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using NFCSetup.Helpers;
using NFCSetup.Services.Data;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Syncfusion.Maui.Core.Hosting;
using ZXing.Net.Maui.Controls;

namespace NFCSetup
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseUserDialogs()
                .ConfigureMopups()
                .ConfigureSyncfusionCore()
                .UseSkiaSharp()
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "FontIconBrand");
                    fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontIcon");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontIconSolid");
                    fonts.AddFont("ElMessiri-Regular.ttf", "Almarai-Regular");
                    fonts.AddFont("ElMessiri-Bold.ttf", "Almarai-Bold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ServicesService>();
            builder.Services.AddScoped<IGenericRepository, GenericRepository>();

            return builder.Build();
        }
    }
}
