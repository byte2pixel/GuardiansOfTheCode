using GuardiansOfTheCode.Enemies;
using GuardiansOfTheCode.Player;
using SpaceWeapons;

namespace GuardiansOfTheCode.Adapters;

public class WeaponAdapter : IWeapon
{
    private readonly ISpaceWeapon _spaceWeapon;

    public WeaponAdapter(ISpaceWeapon spaceWeapon)
    {
        _spaceWeapon = spaceWeapon;
    }

    public string Name => _spaceWeapon.SpaceWeaponName;
    public int Damage => _spaceWeapon.ImpactDamage + _spaceWeapon.LaserDamage;
    public void Use(IAnsiConsole console, IEnemy enemy)
    {
        var damage = _spaceWeapon.Shoot();
        enemy.Health -= damage;
        enemy.DamageIndicator.NotifyAboutDamage(enemy.Health, damage);
    }
}
