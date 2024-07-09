using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace TripLoggerPublic.ViewModel;

public partial class MainViewModel : ObservableObject {
    [RelayCommand]
    async Task start() {
        // Navigate to a new page
        await Shell.Current.GoToAsync(nameof(AddEntry));
    }
}

