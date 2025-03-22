namespace GuardiansOfTheCode.Battlefields;

public abstract class BattlefieldTemplate
{
    public abstract string Name { get; }

    public virtual string DescribeSky => "The sky is [bold]clear and [blue]blue[/][/].";

    public abstract string DescribeGround { get; }

    public abstract string DescribeWeather { get; }

    public abstract string DescribeEffects { get; }

    public string Describe => $"{Name}\n{DescribeSky}\n{DescribeGround}\n{DescribeWeather}\n{DescribeEffects}";
}
