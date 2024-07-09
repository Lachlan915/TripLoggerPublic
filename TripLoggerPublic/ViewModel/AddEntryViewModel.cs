using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Diagnostics;

namespace TripLoggerPublic.ViewModel;
public partial class AddEntryViewModel : ObservableObject {
    public ObservableCollection<TripLogger> Logger { get; } = new ObservableCollection<TripLogger>();

    [ObservableProperty]
    int startOdometer;

    [ObservableProperty]
    int endOdometer;

    [ObservableProperty]
    DateTime date = DateTime.Now.Date;

    private string _purpose;
    public string Purpose {
        get => _purpose;
        set => SetProperty(ref _purpose, value);
    }

    public AddEntryViewModel() {
        AddTripCommand = new AsyncRelayCommand(AddTripAsync);
    }

    public IAsyncRelayCommand AddTripCommand { get; }

    private async Task AddTripAsync() {
        // Validate inputs
        if (StartOdometer <= 0 || EndOdometer <= 0 || string.IsNullOrEmpty(Purpose)) {
            // Show validation error message
            ShowToast("Please fill in all fields correctly.");
            return;
        }

        // If startOdometer is larger or the same as the endOdometer
        if (StartOdometer >= EndOdometer) {
            ShowToast("The end odometer must be greater than teh starting odometer.");
            return;
        }

        // Check purpose against 'work' or 'personal'
        if (!string.IsNullOrEmpty(Purpose)) { 
            var input = Purpose.Trim().ToLower();
            if (input == "work" || input == "personal") { 
                SetProperty(ref _purpose, char.ToUpper(input[0]) + input.Substring(1));
            } else {
                ShowToast("Invalid purpose. Please enter 'Work' or 'Personal'.");
                return;
            }
        }

        var logger = new TripLogger {
            StartOdometer = startOdometer,
            EndOdometer = endOdometer,
            Date = date,
            Kilometers = endOdometer - startOdometer,
            Purpose = Purpose
        };
        await App.Database.SaveOdometerAsync(logger);
        ShowToast("Entry logged successfully!");
    }

    [RelayCommand]
    async Task ViewTrips() {
        await Shell.Current.GoToAsync(nameof(ViewTrips));
    }

    private void ShowToast(string message) {
        var toast = Toast.Make(message, ToastDuration.Short, 14);
        toast.Show();
    }
}