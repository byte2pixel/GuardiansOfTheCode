using GuardiansOfTheCode.Enemies;

namespace GuardiansOfTheCode.Player;

public class IceStaff(int damage, int paralyzedFor) : IWeapon
{
    public IceStaff() : this(10, 2)
    {
    }

    public string Name { get; } = "Ice Staff";
    public int Damage { get; } = damage;
    public int ParalyzedFor { get; } = paralyzedFor;

    public void Use(IAnsiConsole console, IEnemy enemy)
    {
        var computedDamage = Math.Min(enemy.Health, Damage);
        enemy.Health -= computedDamage;
        enemy.DamageIndicator.NotifyAboutDamage(enemy.Health, computedDamage);
        if (enemy.Health <= 0 || enemy.Paralyzed || new Random().Next(1, 4) != 1) return;
        console.MarkupLineInterpolated($"The {enemy.Name} is paralyzed and can't move for {ParalyzedFor} turns.");
        enemy.Paralyzed = true;
        enemy.ParalyzedFor = 2;
    }
}
