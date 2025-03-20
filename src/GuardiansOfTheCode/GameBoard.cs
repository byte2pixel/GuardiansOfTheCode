using Common;
using GuardiansOfTheCode.Adapters;
using GuardiansOfTheCode.Enemies;
using GuardiansOfTheCode.Player;
using SpaceWeapons;

namespace GuardiansOfTheCode;

public class GameBoard(IAnsiConsole console, PrimaryPlayer player, EnemyFactory enemyFactory, IApiService apiService)
{
    public async Task PlayArea(int level)
    {
        if (level == 1)
        {
            player.Cards = await GetCards();
            PlayFirstLevel();
        }
        else if (level == -1)
        {
            var choice = console.Prompt(new TextPrompt<bool>("Do you want to play the first level?").DefaultValue(true).AddChoice(true).AddChoice(false));
            if (choice)
            {
                PlaySpecialLevel();
            }
        }
    }

    private void PlaySpecialLevel()
    {
        player.Weapon = new WeaponAdapter(new AcmeLaser());
        console.MarkupLineInterpolated($"Player {player.Name} is using a {player.Weapon.Name}!");
        var enemy = enemyFactory.Spawn<Zombie>();
        console.MarkupLineInterpolated($"{player.Name} is fighting a level {enemy.Level} {enemy.GetType().Name}!");
        player.Weapon.Use(enemy);
    }

    private void PlayFirstLevel()
    {
        // spawn 10 zombies
        List<IEnemy> enemies = [];
        AddEnemies<Zombie>(enemies, 10);

        // spawn 3 werewolves
        AddEnemies<Werewolf>(enemies, 3);

        foreach (var enemy in enemies)
        {
            console.MarkupLineInterpolated($"{player.Name} is fighting a level {enemy.Level} {enemy.GetType().Name}!");
            while (BothAlive(enemy))
            {
                console.MarkupLineInterpolated($"The player attacks the enemy! with {player.Weapon.Name}");
                player.Weapon.Use(enemy);

                if (enemy.Health <= 0)
                {
                    console.MarkupLineInterpolated($"Enemy has been defeated!");
                    enemyFactory.Reclaim(enemy);
                    break;
                }

                EnemyAttacks(enemy);

                if (player.Health > 0) continue;

                console.MarkupLineInterpolated($"Player {player.Name} has been defeated!");
                break;
            }
        }
    }

    private void EnemyAttacks(IEnemy enemy)
    {
        if (enemy.Paralyzed)
        {
            enemy.ParalyzedFor--;
            if (enemy.ParalyzedFor == 0)
            {
                enemy.Paralyzed = false;
            }
        }
        else
        {
            enemy.Attack(player);
        }
    }

    private bool BothAlive(IEnemy enemy)
    {
        return enemy.Health > 0 && player.Health > 0;
    }

    private void AddEnemies<T>(List<IEnemy> enemies, int count) where T : IEnemy
    {
        for (var i = 0; i < count; i++)
        {
            enemies.Add(enemyFactory.Spawn<T>());
        }
    }

    private async Task<IEnumerable<Card>> GetCards()
    {
        return await apiService.GetCards();
    }
}
