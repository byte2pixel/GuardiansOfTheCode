using Common;
using GuardiansOfTheCode.Facades;

namespace GuardiansOfTheCode.Commands;

// ReSharper disable once ClassNeverInstantiated.Global
public class PlayCommand(GameBoardFacade gameBoard) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        await gameBoard.Play(-1);
        TestDecorators();
        TestCompositePattern();
        return 0;
    }

    private static void TestDecorators()
    {
        var soldier = new Card("Soldier", 25, 20);
        soldier = new AttackDecorator(soldier, "Sword", 15);
        soldier = new AttackDecorator(soldier, "Amulet", 5);
        soldier = new DefenseDecorator(soldier, "Helmet", 10);
        soldier = new DefenseDecorator(soldier, "Heavy Armor", 45);
        AnsiConsole.Console.MarkupLineInterpolated(
            $"Name: {soldier.Name}, Attack: {soldier.Attack}, Defense: {soldier.Defense}"
        );
    }

    private static void TestCompositePattern()
    {
        CardDeck deck = new();
        CardDeck attackDeck = new();
        CardDeck defenseDeck = new();

        attackDeck.Add(new Card("Sword", 15, 0));
        attackDeck.Add(new Card("Axe", 20, 0));
        attackDeck.Add(new Card("Bow", 10, 0));

        defenseDeck.Add(new Card("Shield", 0, 10));
        defenseDeck.Add(new Card("Helmet", 0, 15));
        defenseDeck.Add(new Card("Armor", 0, 20));

        deck.Add(attackDeck);
        deck.Add(new Card("Goblin", 10, 5));
        deck.Add(new Card("Wizard", 30, 0));
        deck.Add(defenseDeck);
        AnsiConsole.Console.WriteLine(deck.Display());
    }
}
