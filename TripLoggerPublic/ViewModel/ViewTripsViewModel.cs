using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TripLoggerPublic.ViewModel;

public partial class ViewTripsViewModel : ObservableObject {

    [ObservableProperty]
    int tripNumber;

    [ObservableProperty]
    DateTime? fromDate;

    [ObservableProperty]
    DateTime? toDate;

    [ObservableProperty]
    int? fromDistance;

    [ObservableProperty]
    int? toDistance;

    private string _purpose;
    public string Purpose {
        get => _purpose;
        set => SetProperty(ref _purpose, value);
    }

    public ViewTripsViewModel() {
        AddEntryCommand = new AsyncRelayCommand(AddEntry);
        SearchTripsCommand = new AsyncRelayCommand(SearchTrips);
    }

    public IAsyncRelayCommand AddEntryCommand { get; }
    public IAsyncRelayCommand SearchTripsCommand { get; }

    private async Task AddEntry() { 
        await Shell.Current.GoToAsync(nameof(AddEntry));
    }

    private async Task SearchTrips() {
        if (!string.IsNullOrEmpty(Purpose)) {
            var input = Purpose.Trim().ToLower();
            if (input == "work" || input == "personal") {
                SetProperty(ref _purpose, char.ToUpper(input[0]) + input.Substring(1));
            } else {
                ShowToast("Invalid purpose. Please enter 'Work' or 'Personal'.");
                return;
            }
        }

        var tripLogs = await App.Database.SearchTripLogsAsync(
            tripNumber,
            fromDate,
            toDate,
            Purpose,
            fromDistance,
            toDistance);

        TripLogService.Instance.TripLogs = tripLogs;
        await Shell.Current.GoToAsync(nameof(TripLogPage));
    }

    private void ShowToast(string message) {
        var toast = Toast.Make(message, ToastDuration.Short, 14);
        toast.Show();
    }
}
