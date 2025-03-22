using GuardiansOfTheCode.Enemies;

namespace GuardiansOfTheCode.Player;

public interface IWeapon
{
    string Name { get; }
    int Damage { get; }
    void Use(IAnsiConsole console, IEnemy enemy);
}
