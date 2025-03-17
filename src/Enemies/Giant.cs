namespace GuardiansOfTheCode.Enemies;

public class Giant(IAnsiConsole console, int health, int level) : IEnemy
{
    public int Health { get; set; } = health;
    public int Level { get; set; } = level;
    public void Attack(PrimaryPlayer player)
    {
        console.MarkupInterpolated($"Giant attacks Player {player.Name}!");
    }

    public void Defend(PrimaryPlayer player)
    {
        console.MarkupInterpolated($"Giant defends against Player {player.Name}!");
    }
}
