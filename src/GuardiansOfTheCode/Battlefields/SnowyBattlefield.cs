namespace GuardiansOfTheCode.Battlefields;

public class SnowyBattlefield : BattlefieldTemplate
{
    public override string Name => "[blue]Arctic[/] Wasteland";
    public override string DescribeSky => "The sky is [grey]cloudy[/] and the [blue]snow[/] is falling.";
    public override string DescribeGround => "The ground is covered with [blue]snow[/] and the [blue]ice[/] is slippery.";

    public override string DescribeWeather => "The weather is [blue]cold[/] and the wind is [blue]freezing[/].";
    public override string DescribeEffects => "The [blue]cold[/] weather is slowing down you and the enemies.";
}
