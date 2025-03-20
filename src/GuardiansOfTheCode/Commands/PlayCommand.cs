namespace GuardiansOfTheCode.Commands;

// ReSharper disable once ClassNeverInstantiated.Global
public class PlayCommand(GameBoard gameBoard) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        await gameBoard.PlayArea(1);
        return 0;
    }
}
