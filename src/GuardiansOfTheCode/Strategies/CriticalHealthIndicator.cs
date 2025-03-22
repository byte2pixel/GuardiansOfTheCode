namespace GuardiansOfTheCode.Strategies;

public class CriticalHealthIndicator(IAnsiConsole console, string name) : IDamageIndicator
{
    public void NotifyAboutDamage(int health, int damage)
    {
        console.MarkupLineInterpolated($"[red]{name} has {health}[/] health left after taking [red]{damage}[/] damage!");
    }
}
