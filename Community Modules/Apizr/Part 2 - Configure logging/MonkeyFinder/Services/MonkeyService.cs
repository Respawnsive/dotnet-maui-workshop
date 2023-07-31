using Apizr;

namespace MonkeyFinder.Services;

public class MonkeyService : IMonkeyService
{
    private readonly IConnectivity _connectivity;
    private readonly IApizrManager<IMonkeyApi> _monkeyApiManager;

    public MonkeyService(IConnectivity connectivity, IApizrManager<IMonkeyApi> monkeyApiManager)
    {
        _connectivity = connectivity;
        _monkeyApiManager = monkeyApiManager;
    }

    private List<Monkey> _currentMonkeys;
    public async Task<List<Monkey>> GetMonkeys()
    {
        if (_currentMonkeys?.Count > 0)
            return _currentMonkeys;

        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            // Offline -> we just inform the user (not blocking) and return local monkeys
            await Shell.Current.DisplayAlert("No connectivity!", $"Local monkeys will be loaded.", "OK");
            _currentMonkeys = await GetLocalMonkeys();
        }
        else
        {
            try
            {
                // Try to call API endpoint with ApizrManager
                _currentMonkeys = await _monkeyApiManager.ExecuteAsync(api => api.GetMonkeysAsync());
                if (_currentMonkeys?.Count == 0)
                {
                    //response not successful, we just inform the user (not blocking) and return local monkeys
                    await Shell.Current.DisplayAlert("Error (ApizrManager)!", "Unable to get monkeys Online, local monkeys will be loaded.", "OK");
                    _currentMonkeys = await GetLocalMonkeys();
                }
            }
            catch(Exception ex)
            {
                // Exception, we just inform the user (not blocking) and return local monkeys
                Debug.WriteLine($"Error : _monkeyApiManager throws : {ex?.Message} ({ex?.StackTrace})");
                await Shell.Current.DisplayAlert("Error (Exception)!", "Unable to get monkeys Online, local monkeys will be loaded.", "OK");
                _currentMonkeys = await GetLocalMonkeys();
            }
        }
        //Here we are sure to have monkeys, either from memory/last call, from API or from local file
        return _currentMonkeys;
    }

    private async Task<List<Monkey>> GetLocalMonkeys()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        return JsonSerializer.Deserialize(contents, MonkeyContext.Default.ListMonkey);
    }
}
