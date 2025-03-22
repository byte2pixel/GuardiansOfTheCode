using GuardiansOfTheCode.Enemies;

namespace GuardiansOfTheCode.Player;

public class FireStaff(int damage, int fireDamage) : IWeapon
{
    public FireStaff() : this(20, 5)
    {
    }

    public string Name { get; } = "Fire Staff";
    public int Damage { get; } = damage;
    public int FireDamage { get; } = fireDamage;

    public void Use(IAnsiConsole console, IEnemy enemy)
    {
        if (enemy.OvertimeDamage > 0)
        {
            var otDamage = Math.Min(enemy.Health, enemy.OvertimeDamage);
            enemy.Health -= otDamage;
            enemy.OvertimeDamage = 0;
            enemy.DamageIndicator.NotifyAboutDamage(enemy.Health, otDamage);
        }
        if (enemy.Health <= 0)
        {
            return;
        }

        var computedDamage = Math.Min(enemy.Health, Damage);
        enemy.Health -= computedDamage;
        enemy.DamageIndicator.NotifyAboutDamage(enemy.Health, computedDamage);
        if (enemy.Health <= 0 || new Random().Next(1, 4) != 1) return;
        enemy.OvertimeDamage += FireDamage;
        console.WriteLine($"The {enemy.Name} is burning and will take {FireDamage} damage the next turn.");
    }
}
