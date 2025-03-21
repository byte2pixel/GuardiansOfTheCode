using GuardiansOfTheCode.Enemies;

namespace GuardiansOfTheCode.Player;

public class Sword(int damage, int armorDamage) : IWeapon
{
    public Sword() : this(15, 0)
    {
    }
    public string Name { get; } = "Sword";
    public int Damage { get; } = damage;
    public int ArmorDamage { get; } = armorDamage;

    public void Use(IEnemy enemy)
    {
        enemy.Health -= Damage;
        enemy.Armor -= Math.Min(enemy.Armor, ArmorDamage);
    }
}
