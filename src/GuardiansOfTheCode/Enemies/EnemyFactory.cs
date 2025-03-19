namespace GuardiansOfTheCode.Enemies;

public class EnemyFactory
{
    public int AreaLevel { get; }
    private readonly Dictionary<Type, Func<IEnemy>> _enemyFactories;

    private readonly Stack<Zombie> _zombiesPool = [];
    private readonly Stack<Werewolf> _werewolvesPool = [];
    private readonly Stack<Giant> _giantsPool = [];
    private readonly IAnsiConsole _console;

    public EnemyFactory(IAnsiConsole console, int areaLevel)
    {
        _console = console;
        AreaLevel = areaLevel;
        _enemyFactories = new Dictionary<Type, Func<IEnemy>>
        {
            [typeof(Zombie)] = () => GetEnemyFromPool(_zombiesPool, FillZombiesPool),
            [typeof(Werewolf)] = () => GetEnemyFromPool(_werewolvesPool, FillWerewolvesPool),
            [typeof(Giant)] = () => GetEnemyFromPool(_giantsPool, FillGiantsPool)
        };
        FillEnemiesPool();
    }

    private void FillZombiesPool()
    {
        var zombiesToSpawn = AreaLevel switch
        {
            < 3 => 10,
            < 6 => 20,
            _ => 30
        };
        for (var i = 0; i < zombiesToSpawn; i++)
        {
            _zombiesPool.Push(CreateZombie());
        }
    }

    private void FillWerewolvesPool()
    {
        var werewolvesToSpawn = AreaLevel switch
        {
            < 3 => 3,
            < 6 => 5,
            _ => 10
        };
        for (var i = 0; i < werewolvesToSpawn; i++)
        {
            _werewolvesPool.Push(CreateWerewolf());
        }
    }

    private void FillGiantsPool()
    {
        var giantsToSpawn = AreaLevel switch
        {
            < 3 => 1,
            < 6 => 2,
            _ => 3
        };
        for (var i = 0; i < giantsToSpawn; i++)
        {
            _giantsPool.Push(CreateGiant());
        }
    }

    private void FillEnemiesPool()
    {
        FillZombiesPool();
        FillWerewolvesPool();
        FillGiantsPool();
    }

    public void Reclaim(IEnemy enemy)
    {
        enemy.Reset();
        switch (enemy)
        {
            case Zombie zombie:
                _zombiesPool.Push(zombie);
                break;
            case Werewolf werewolf:
                _werewolvesPool.Push(werewolf);
                break;
            case Giant giant:
                _giantsPool.Push(giant);
                break;
        }
    }

    private Werewolf CreateWerewolf() => AreaLevel switch
    {
        < 3 => new Werewolf(_console, 100, 5),
        < 6 => new Werewolf(_console, 100, 10),
        _ => new Werewolf(_console, 100, 15)
    };

    private Giant CreateGiant() => AreaLevel switch
    {
        < 3 => new Giant(_console, 100, 10),
        < 6 => new Giant(_console, 100, 20),
        _ => new Giant(_console, 100, 30)
    };

    private Zombie CreateZombie() => AreaLevel switch
    {
        < 3 => new Zombie(_console, 50, 2, 10),
        < 6 => new Zombie(_console, 66, 5, 15),
        _ => new Zombie(_console, 100, 10, 20)
    };


    private static TEnemy GetEnemyFromPool<TEnemy>(Stack<TEnemy> pool, Action fillPool) where TEnemy : IEnemy
    {
        if (pool.Count == 0)
        {
            fillPool();
        }
        return pool.Pop();
    }

    public T Spawn<T>() where T : IEnemy
    {
        if (!_enemyFactories.TryGetValue(typeof(T), out var factory))
            throw new ArgumentException($"Unsupported enemy type: {typeof(T).Name}");

        return (T)factory();
    }
}
