using Common;

namespace Api.Services;

public class CardService : ICardService
{
    public IEnumerable<Card> GetCards()
    {
        return (List<Card>)
        [
            new Card { Name = "Ultimate Shadow Wraith", Attack = 90, Defense = 80 },
            new Card { Name = "Puppet of Doom", Attack = 64, Defense = 91 },
            new Card { Name = "Lost Soul", Attack = 77, Defense = 61 },
            new Card { Name = "Soul of the Damned", Attack = 85, Defense = 75 },
            new Card { Name = "Plague Druid", Attack = 55, Defense = 57 },
            new Card { Name = "Rage Dragon", Attack = 90, Defense = 95 }
        ];
    }
}
