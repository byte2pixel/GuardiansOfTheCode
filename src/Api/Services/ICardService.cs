using Common;

namespace Api.Services;

public interface ICardService
{
    public IEnumerable<Card> GetCards();
}
