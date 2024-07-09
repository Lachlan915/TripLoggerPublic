using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripLoggerPublic.ViewModel;
public partial class TripLogViewModel : ObservableObject {
    public ObservableCollection<TripLogger> TripLogs { get; } = new ObservableCollection<TripLogger>();

    [ObservableProperty]
    private int totalKilometers;

    public TripLogViewModel() {
        ViewTripsCommand = new AsyncRelayCommand(ViewTrips);
        IndividualTripCommand = new AsyncRelayCommand<TripLogger>(IndividualTrip);
        LoadTripLogs();
    }

    public IAsyncRelayCommand ViewTripsCommand { get; }
    public IAsyncRelayCommand IndividualTripCommand { get; }

    private async Task ViewTrips() {
        await Shell.Current.GoToAsync(nameof(ViewTrips));
    }

    private async Task IndividualTrip(TripLogger trip) {
        var navigationParamter = new Dictionary<string, object> {
            { "SelectTrip", trip }
        };
        await Shell.Current.GoToAsync(nameof(IndividualTripPage), navigationParamter);
    }

    private void LoadTripLogs() {
        var tripLogs = TripLogService.Instance.TripLogs;

        if (tripLogs != null && tripLogs.Any()) {
            TripLogs.Clear();
            foreach (var trip in tripLogs) { 
                TripLogs.Add(trip);
                TotalKilometers += trip.Kilometers;
            }
        }
    }
}
