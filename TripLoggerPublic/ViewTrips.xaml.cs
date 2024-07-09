using TripLoggerPublic.ViewModel;

namespace TripLoggerPublic;

public partial class ViewTrips : ContentPage {
	public ViewTrips() {
		InitializeComponent();

        // Hide the navigation bar
        AppShell.SetNavBarIsVisible(this, false);
    }
}