using GuardiansOfTheCode.Enemies;
using GuardiansOfTheCode.Player;

namespace GuardiansOfTheCode;

public class GameBoard(IAnsiConsole console, EnemyFactory enemyFactory)
{
    private readonly PrimaryPlayer _player = PrimaryPlayer.Instance;

    public void PlayArea(int level)
    {
        if (level == 1)
        {
            PlayFirstLevel();
        }
    }

    private void PlayFirstLevel()
    {
        // spawn 10 zombies
        List<IEnemy> enemies = [];
        for (var i = 0; i < 10; i++)
        {
            enemies.Add(enemyFactory.Spawn<Zombie>());
        }

        // spawn 3 werewolves
        for (var i = 0; i < 3; i++)
        {
            enemies.Add(enemyFactory.Spawn<Werewolf>());
        }

        foreach (var enemy in enemies)
        {
            console.MarkupLineInterpolated($"{_player.Name} is fighting a level {enemy.Level} {enemy.GetType().Name}!");
            while (enemy.Health > 0 && _player.Health > 0)
            {
                console.MarkupLineInterpolated($"The player attacks the enemy! with {_player.Weapon.Name}");
                _player.Weapon.Use(enemy);

                if (enemy.Health <= 0)
                {
                    console.MarkupLineInterpolated($"Enemy has been defeated!");
                    enemyFactory.Reclaim(enemy);
                    break;
                }

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
                    enemy.Attack(_player);
                }

                if (_player.Health > 0) continue;
                console.MarkupLineInterpolated($"Player {_player.Name} has been defeated!");
                break;
            }
        }
    }
}
