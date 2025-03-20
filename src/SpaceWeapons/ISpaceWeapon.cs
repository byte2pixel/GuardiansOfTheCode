namespace SpaceWeapons;

public interface ISpaceWeapon
{
    string SpaceWeaponName { get; }
    int ImpactDamage { get; }
    int LaserDamage { get; }
    int MissChance { get; }
    int Shoot();
}
