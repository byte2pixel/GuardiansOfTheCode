namespace GuardiansOfTheCode.Battlefields;

public class VolcanoBattlefield : BattlefieldTemplate
{
    public override string Name => "[red]Scorched Earth[/]";
    public override string DescribeSky =>
        "The sky is [red]red[/] and [yellow]orange[/], with [grey]smoke[/] rising from a [red]volcano[/].";
    public override string DescribeGround => "The ground is [red]hot[/] and [yellow]cracked[/], with [red]lava[/] flowing in the distance.";
    public override string DescribeWeather => "The weather is [red]hot[/] and [yellow]dry[/], with [grey]ash[/] falling all around.";
    public override string DescribeEffects => "The [red]heat[/] is unbearable, making it [yellow]hard to breathe[/].";
}
