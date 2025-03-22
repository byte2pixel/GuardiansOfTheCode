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
        IEnemy? currentEnemy = null;

        while(true)
        {
            if (currentEnemy != null) continue;
            if (enemies.Count > 0)
            {
                currentEnemy = enemies[0];
                enemies.Remove(currentEnemy);
            }
            else
            {
                console.MarkupLineInterpolated($"[green]Player {player.Name} has defeated all enemies![/]");
                break;
            }

            console.MarkupLineInterpolated($"{player.Name} is fighting a level {currentEnemy.Level} {currentEnemy.Name}!");
            while (BothAlive(currentEnemy))
            {
                console.MarkupLineInterpolated($"The player attacks {currentEnemy.Name} with the {player.Weapon.Name}");
                player.Weapon.Use(console, currentEnemy);

                if (currentEnemy.Health <= 0)
                {
                    console.MarkupLineInterpolated($"{currentEnemy.Name} has been defeated!");
                    enemyFactory?.Reclaim(currentEnemy);
                    currentEnemy = null;
                    break;
                }

                EnemyAttacks(currentEnemy);

                if (player.Health > 0) continue;

                console.MarkupLineInterpolated($"Player {player.Name} has been defeated!");
                return;
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
            var damage = enemy.Attack(player);
            console.MarkupLineInterpolated($"{enemy.Name} attacks the player for {damage} damage!");
            player.Health -= damage;
            player.DamageIndicator.NotifyAboutDamage(player.Health, damage);
        }
    }

    private bool BothAlive(IEnemy enemy)
    {
        return enemy.Health > 0 && player.Health > 0;
    }
}
