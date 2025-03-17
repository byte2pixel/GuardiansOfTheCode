namespace GuardiansOfTheCode.Enemies;

public class Zombie(IAnsiConsole console, int health, int level) : IEnemy
{
    public int Health { get; } = health;
    public int Level { get; } = level;
    public void Attack(PrimaryPlayer player)
    {
        console.MarkupInterpolated($"Zombie attacks Player {player.Name}!");
    }

    public void Defend(PrimaryPlayer player)
    {
        console.MarkupInterpolated($"Zombie defends against Player {player.Name}!");
    }
}
