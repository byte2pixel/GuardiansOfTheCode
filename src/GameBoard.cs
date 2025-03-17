using GuardiansOfTheCode.Enemies;

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
        int level = 1;
        // spawn 10 zombies
        List<IEnemy> enemies = [];
        for (int i = 0; i < 10; i++)
        {
            enemies.Add(enemyFactory.SpawnZombie(level));
        }

        // spawn 3 werewolves
        for (int i = 0; i < 3; i++)
        {
            enemies.Add(enemyFactory.SpawnWerewolf(level));
        }

        foreach (var enemy in enemies)
        {
            console.MarkupLineInterpolated($"Player {_player.Name} encounters {enemy.GetType().Name}!");
        }
    }
}
