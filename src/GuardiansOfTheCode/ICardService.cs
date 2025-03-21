using Common;

namespace GuardiansOfTheCode;

public interface ICardService
{
    public Task<IEnumerable<Card>> GetCards();
}
