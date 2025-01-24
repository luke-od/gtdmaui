using GTDApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls; // Add this using directive

namespace gtdmaui
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static async void InboxListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Item selectedItem)
            {
                var navigation = ((App)Application.Current).MainPage.Navigation; // Get the Navigation instance
                await navigation.PushAsync(new ItemEditPage(selectedItem));
            }
        }
    }
}