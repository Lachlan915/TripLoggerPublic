namespace TripLoggerPublic
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddEntry), typeof(AddEntry));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ViewTrips), typeof(ViewTrips));
            Routing.RegisterRoute(nameof(TripLogPage), typeof(TripLogPage));
            Routing.RegisterRoute(nameof(IndividualTripPage), typeof(IndividualTripPage));
        }
    }
}
