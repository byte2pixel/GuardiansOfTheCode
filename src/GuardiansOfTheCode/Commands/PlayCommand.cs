using Common;
using GuardiansOfTheCode.Facades;
using GuardiansOfTheCode.Player;

namespace GuardiansOfTheCode.Commands;

// ReSharper disable once ClassNeverInstantiated.Global
public class PlayCommand(GameBoardFacade gameBoard) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        await gameBoard.Play(-1);
        TestDecorators();
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
}
