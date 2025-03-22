namespace GuardiansOfTheCode.Strategies;

public class RegularDamageIndicator(IAnsiConsole console, string name) : IDamageIndicator
{
    public void NotifyAboutDamage(int health, int damage)
    {
        if (health < 30) return;
        console.MarkupLineInterpolated($"{name} has [blue]{health}[/] health left after taking [red]{damage}[/] damage!");
    }
}
