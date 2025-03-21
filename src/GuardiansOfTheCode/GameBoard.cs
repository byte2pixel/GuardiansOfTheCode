using GuardiansOfTheCode.Enemies;
using GuardiansOfTheCode.Player;

namespace GuardiansOfTheCode;

public class GameBoard(IAnsiConsole console, PrimaryPlayer player, EnemyFactory? enemyFactory, List<IEnemy> enemies)
{
    public void PlayArea(int level)
    {
        if (level == 1)
        {
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
        // Special level code
    }

    private void PlayFirstLevel()
    {
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
                    enemyFactory?.Reclaim(enemy);
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
}
