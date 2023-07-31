using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    private readonly IMonkeyService _monkeyService;
    private readonly IGeolocation _geolocation;

    public MonkeysViewModel(IGeolocation geolocation, IMonkeyService monkeyService)
    {
        Title = "Monkey Finder";
        _monkeyService = monkeyService;
        _geolocation = geolocation;
    }

    public ObservableCollection<Monkey> Monkeys { get; } = new();

    [ObservableProperty] private bool _isRefreshing;

    [RelayCommand]
    private async Task GoToDetails(Monkey monkey)
    {
        if (monkey == null)
            return;

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Monkey", monkey }
        });
    }

    [RelayCommand]
    private async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        IsBusy = true;
        var monkeys = await _monkeyService.GetMonkeys();

        if (Monkeys.Count != 0)
            Monkeys.Clear();

        foreach(var monkey in monkeys)
            Monkeys.Add(monkey);

        IsBusy = false;
        IsRefreshing = false;

    }

    [RelayCommand]
    private async Task GetClosestMonkey()
    {
        if (IsBusy || Monkeys.Count == 0)
            return;

        try
        {
            // Get cached location, else get real location.
            var location = await _geolocation.GetLastKnownLocationAsync() ??
                           await _geolocation.GetLocationAsync(new GeolocationRequest
                           {
                               DesiredAccuracy = GeolocationAccuracy.Medium,
                               Timeout = TimeSpan.FromSeconds(30)
                           });

            // Find closest monkey to us
            var first = Monkeys.MinBy(m => location.CalculateDistance(
                new Location(m.Latitude, m.Longitude), DistanceUnits.Miles));

            await Shell.Current.DisplayAlert("", first.Name + " " +
                first.Location, "OK");

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to query location: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
    }
}
