using TripLoggerPublic.ViewModel;

namespace TripLoggerPublic;

public partial class TripLogPage : ContentPage {
	public TripLogPage() { 
		InitializeComponent();
        BindingContext = new TripLogViewModel();

        // Hide the navigation bar
        AppShell.SetNavBarIsVisible(this, false);
    }
}