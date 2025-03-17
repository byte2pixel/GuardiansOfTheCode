namespace GuardiansOfTheCode.Commands;

// ReSharper disable once ClassNeverInstantiated.Global
public class PlayCommand(GameBoard gameBoard) : Command
{
    public override int Execute(CommandContext context)
    {
        gameBoard.PlayArea(1);
        return 0;
    }
}
