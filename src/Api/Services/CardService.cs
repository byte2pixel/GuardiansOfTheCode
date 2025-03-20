using Common;

namespace Api.Services;

public class CardService : ICardService
{
    public IEnumerable<Card> GetCards()
    {
        return (List<Card>)
        [
            new Card("Ultimate Shadow Wraith", 90, 80),
            new Card("Puppet of Doom", 64, 91),
            new Card("Lost Soul", 77, 61),
            new Card("Soul of the Damned", 85, 75),
            new Card("Darkness Incarnate", 99, 99),
            new Card("Plague Druid", 55, 57),
            new Card("Soulless Knight", 70, 65),
            new Card("Rage Dragon", 90, 95)
        ];
    }
}
