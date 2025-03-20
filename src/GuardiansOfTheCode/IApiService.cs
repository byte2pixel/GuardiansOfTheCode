using Common;

namespace GuardiansOfTheCode;

public interface IApiService
{
    public Task<IEnumerable<Card>> GetCards();
}
