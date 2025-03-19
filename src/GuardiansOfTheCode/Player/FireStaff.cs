using GuardiansOfTheCode.Enemies;

namespace GuardiansOfTheCode.Player;

public class FireStaff(int damage, int fireDamage) : IWeapon
{
    public string Name { get; } = "Fire Staff";
    public int Damage { get; } = damage;
    public int FireDamage { get; } = fireDamage;

    public void Use(IEnemy enemy)
    {
        enemy.Health -= Damage;
        enemy.OvertimeDamage += FireDamage;
    }
}
