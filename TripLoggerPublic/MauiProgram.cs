using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TripLoggerPublic.ViewModel;

namespace TripLoggerPublic
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            _ = builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<AddEntry>();
            builder.Services.AddTransient<AddEntryViewModel>();

            builder.Services.AddTransient<ViewTrips>();
            builder.Services.AddTransient<ViewTripsViewModel>();

            builder.Services.AddTransient<TripLogPage>();
            builder.Services.AddTransient<TripLogViewModel>();

            builder.Services.AddTransient<IndividualTripPage>();
            builder.Services.AddTransient<IndividualTripViewModel>();

            return builder.Build();
        }
    }
}
