using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripLoggerPublic.ViewModel;
public partial class IndividualTripViewModel : ObservableObject {
    private TripLogger tripDetails;
    
    private int tripID;
    public int TripID {
        get => tripID;
        set { 
            if (SetProperty(ref tripID, value)) {
                LoadTripDetails();
            }
        }
    }

    public TripLogger TripDetails { 
        get => tripDetails;
        set => SetProperty(ref tripDetails, value);
    }

    public IndividualTripViewModel() {
        TripLogCommand = new AsyncRelayCommand(TripLog);
    }

    public IAsyncRelayCommand TripLogCommand { get; }

    private async Task TripLog() {
        await Shell.Current.GoToAsync(nameof(TripLogPage));
    }

    public void LoadTripDetails() {
        // Fetch trip Details from the service based on TripID
        TripDetails = TripLogService.Instance.GetTripLogByTripID(TripID);
    }

    //[ObservableProperty]
    //private TripLogger selectedTrip;

    //public void Initialise(TripLogger trip) {
    //    SelectedTrip = trip;
    //}
}
