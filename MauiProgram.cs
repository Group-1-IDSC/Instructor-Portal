using Syncfusion.Maui.Core.Hosting;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;


namespace LoginForm;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .ConfigureSyncfusionCore()
            .UseMauiApp<App>() // Must be first in the chain
            .UseMauiCommunityToolkitCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}