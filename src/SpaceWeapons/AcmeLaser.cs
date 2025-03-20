namespace SpaceWeapons;

public class AcmeLaser : ISpaceWeapon
{
    public string SpaceWeaponName => "Acme Laser";
    public int ImpactDamage => 1;
    public int LaserDamage => 1;
    public int MissChance => 75;

    public int Shoot()
    {
        var random = new Random();
        return random.Next(1, 101) > MissChance ? ImpactDamage + LaserDamage : 0;
    }
}
