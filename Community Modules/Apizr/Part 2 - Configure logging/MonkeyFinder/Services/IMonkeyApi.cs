using Apizr;
using Refit;

namespace MonkeyFinder.Services;

[WebApi("https://www.montemagno.com")]
public interface IMonkeyApi
{
    [Get("/monkeys.json")]
    Task<List<Monkey>> GetMonkeysAsync();
}