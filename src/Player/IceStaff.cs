using GuardiansOfTheCode.Enemies;

namespace GuardiansOfTheCode.Player;

public class IceStaff(int damage, int paralyzedFor) : IWeapon
{
    public string Name { get; } = "Ice Staff";
    public int Damage { get; } = damage;
    public int ParalyzedFor { get; } = paralyzedFor;

    public void Use(IEnemy enemy)
    {
        enemy.Health -= Damage;
        enemy.Paralyzed = true;
        enemy.ParalyzedFor = ParalyzedFor;
    }
}
