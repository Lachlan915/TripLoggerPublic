using Microsoft.Maui.Controls;
using TripLoggerPublic.ViewModel;

namespace TripLoggerPublic
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;

            // Hide the navigation bar
            AppShell.SetNavBarIsVisible(this, false);
        }
    }
}
