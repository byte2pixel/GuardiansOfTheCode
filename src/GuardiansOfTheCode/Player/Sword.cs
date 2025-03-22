using GuardiansOfTheCode.Enemies;

namespace GuardiansOfTheCode.Player;

public class Sword(int damage, int armorDamage) : IWeapon
{
    public Sword() : this(15, 10)
    {
    }
    public string Name { get; } = "Sword";
    public int Damage { get; } = damage;
    public int ArmorDamage { get; } = armorDamage;

    public void Use(IAnsiConsole console, IEnemy enemy)
    {
        // The computed damage is the minimum between the enemy's health and the sword's damage
        // reduced by the enemy's armor
        var computedDamage = Math.Min(enemy.Health, Damage - enemy.Armor);
        enemy.Health -= computedDamage;
        enemy.DamageIndicator.NotifyAboutDamage(enemy.Health, computedDamage);
        if (enemy.Armor == 0) return;
        var armorReduction = Math.Min(enemy.Armor, ArmorDamage);
        console.MarkupLineInterpolated($"The {enemy.Name} lost {armorReduction} armor points.");
        enemy.Armor -= armorReduction;
    }
}
