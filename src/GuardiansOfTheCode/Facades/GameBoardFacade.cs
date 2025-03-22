using GuardiansOfTheCode.Battlefields;
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
        ConfigureTheBattlefield();
        await AddPlayerCards();
        InitializeEnemyFactory(areaLevel);
        LoadZombies();
        LoadWerewolves();
        LoadGiants();
        var gameBoard = new GameBoard(console, player, _enemyFactory, _enemies);
        gameBoard.PlayArea(areaLevel);
    }

    private void ConfigureTheBattlefield()
    {

        // Find all non-abstract classes that implement BattlefieldTemplate
        var battlefield = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(BattlefieldTemplate).IsAssignableFrom(t) && t is { IsAbstract: false })
            .ToList();
        var availableFields = new List<BattlefieldTemplate>();
        foreach (var type in battlefield)
        {
            try
            {
                if (Activator.CreateInstance(type) is BattlefieldTemplate field)
                {
                    availableFields.Add(field);
                }
            }
            catch (Exception)
            {
                // Ignore any BattlefieldTemplate that cannot be instantiated
            }
        }
        if (availableFields.Count == 0)
        {
            console.MarkupLine("[red]No battlefields available![/]");
            return;
        }

        var selectedField = console.Prompt(
            new SelectionPrompt<BattlefieldTemplate>()
                .Title("Choose your battlefield!")
                .PageSize(5)
                .AddChoices(availableFields)
                .UseConverter(f => f.Name)
        );
        console.MarkupLine(selectedField.Describe);
        console.WriteLine();
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
