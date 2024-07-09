namespace TripLoggerPublic;

public partial class IndividualTripPage : ContentPage {
	public IndividualTripPage()	{
		InitializeComponent();

        // Hide the navigation bar
        AppShell.SetNavBarIsVisible(this, false);
    }
}