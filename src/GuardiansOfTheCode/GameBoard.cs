using GuardiansOfTheCode.BattleCommands;
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
                console.MarkupLineInterpolated($"[green]{player.Name} has defeated all enemies![/]");
                break;
            }

            console.MarkupLineInterpolated($"[green]{player.Name}[/] is fighting a level [red]{currentEnemy.Level} {currentEnemy.Name}[/]!");
            console.MarkupLineInterpolated($"The [red]{currentEnemy.Name}[/] has [red]{currentEnemy.Health}[/] health!");
            var commands = GetBattleCommands(currentEnemy);
            foreach (var command in commands)
            {
                command.Execute();
                if (currentEnemy.Health <= 0)
                {
                    console.MarkupLineInterpolated($"{currentEnemy.Name} has been defeated!");
                    enemyFactory?.Reclaim(currentEnemy);
                    currentEnemy = null;
                    break;
                }

                if (player.Health > 0) continue;
                console.MarkupLineInterpolated($"[bold][red]{player.Name} has been defeated![/][/]");
                return;
            }
        }
    }

    private List<IBattleCommand> GetBattleCommands(IEnemy enemy)
    {
        List<IBattleCommand> commands =
        [
            new PlayerEnemyBattle(console, player, enemy)
        ];
        commands.AddRange(player.Cards.Select(card => new CardEnemyBattleCommand(console, card, enemy)));
        // randomize the order
        commands = commands.OrderBy(_ => Guid.NewGuid()).ToList();
        return commands;
    }
}
