namespace GuardiansOfTheCode.Enemies;

public class Werewolf(IAnsiConsole console, int health, int level) : IEnemy
{
    public int Health { get; } = health;
    public int Level { get; } = level;
    public void Attack(PrimaryPlayer player)
    {
        console.MarkupInterpolated($"Werewolf attacks Player {player.Name}!");
    }

    public void Defend(PrimaryPlayer player)
    {
        console.MarkupInterpolated($"WereWolf defends against Player {player.Name}!");
    }
}
