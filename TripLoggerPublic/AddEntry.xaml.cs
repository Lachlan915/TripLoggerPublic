using TripLoggerPublic.ViewModel;

namespace TripLoggerPublic;
public partial class AddEntry : ContentPage {  
	public AddEntry() { 
		InitializeComponent();

        // Hide the navigation bar
        AppShell.SetNavBarIsVisible(this, false);
    }
}
