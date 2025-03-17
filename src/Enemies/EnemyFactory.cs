namespace GuardiansOfTheCode.Enemies;

public class EnemyFactory(IAnsiConsole console)
{
    public Werewolf SpawnWerewolf(int areaLevel) => areaLevel switch
    {
        < 3 => new Werewolf(console, 100, 5),
        < 6 => new Werewolf(console, 100, 10),
        _ => new Werewolf(console, 100, 15)
    };

    public Giant SpawnGiant(int areaLevel) => areaLevel switch
    {
        < 3 => new Giant(console, 100, 10),
        < 6 => new Giant(console, 100, 20),
        _ => new Giant(console, 100, 30)
    };

    public Zombie SpawnZombie(int areaLevel) => areaLevel switch
    {
        < 3 => new Zombie(console, 50, 2),
        < 6 => new Zombie(console, 66, 5),
        _ => new Zombie(console, 100, 10)
    };
}
