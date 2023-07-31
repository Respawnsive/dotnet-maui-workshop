namespace MonkeyFinder.ViewModel;

[QueryProperty(nameof(Monkey), "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    private readonly IMap _map;
    public MonkeyDetailsViewModel(IMap map)
    {
        _map = map;
    }

    [ObservableProperty] private Monkey _monkey;

    [RelayCommand]
    private async Task OpenMap()
    {
        try
        {
            await _map.OpenAsync(Monkey.Latitude, Monkey.Longitude, new MapLaunchOptions
            {
                Name = Monkey.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to launch maps: {ex.Message}");
            await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
        }
    }
}
