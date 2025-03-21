using GuardiansOfTheCode.Enemies;
using GuardiansOfTheCode.Player;

namespace GuardiansOfTheCode.Facades;

public class GameBoardFacade(
    IAnsiConsole console,
    PrimaryPlayer player,
    ICardService cardService
)
{
    private EnemyFactory? _enemyFactory;
    private readonly List<IEnemy> _enemies = [];

    public async Task Play(int areaLevel)
    {
        ConfigurePlayerWeapon();
        await AddPlayerCards();
        InitializeEnemyFactory(areaLevel);
        LoadZombies();
        LoadWerewolves();
        LoadGiants();
        var gameBoard = new GameBoard(console, player, _enemyFactory, _enemies);
        gameBoard.PlayArea(areaLevel);
    }

    private void ConfigurePlayerWeapon()
    {
        // Find all non-abstract classes that implement IWeapon
        var weaponTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IWeapon).IsAssignableFrom(t) && t is { IsInterface: false, IsAbstract: false })
            .ToList();

         // Create instances of each weapon type
        var availableWeapons = new List<IWeapon>();
        foreach (var type in weaponTypes)
        {
            try
            {
                if (Activator.CreateInstance(type) is IWeapon weapon)
                {
                    availableWeapons.Add(weapon);
                }
            }
            catch (Exception)
            {
                // Ignore any IWeapon that cannot be instantiated
            }
        }

        if (availableWeapons.Count == 0)
        {
            console.MarkupLine("[red]No weapons available![/]");
            return;
        }

        var selectedWeapon = console.Prompt(
            new SelectionPrompt<IWeapon>()
                .Title("Choose your weapon")
                .PageSize(5)
                .AddChoices(availableWeapons)
                .UseConverter(w => w.Name)
        );

        player.Weapon = selectedWeapon;
        console.MarkupLineInterpolated($"[green]You selected the [bold]{selectedWeapon.Name}[/][/]");
    }

    private async Task AddPlayerCards()
    {
        player.Cards = await cardService.GetCards();
    }

    private void InitializeEnemyFactory(int areaLevel)
    {
        _enemyFactory = new EnemyFactory(console, areaLevel);
    }

    private void LoadZombies()
    {
        _enemies.AddRange(_enemyFactory?.SpawnMany<Zombie>() ?? []);
    }

    private void LoadWerewolves()
    {
        _enemies.AddRange(_enemyFactory?.SpawnMany<Werewolf>() ?? []);
    }

    private void LoadGiants()
    {
        _enemies.AddRange(_enemyFactory?.SpawnMany<Giant>() ?? []);
    }
}
