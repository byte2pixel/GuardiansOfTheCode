using Common;
using GuardiansOfTheCode.Enemies;

namespace GuardiansOfTheCode.BattleCommands;

public class CardEnemyBattleCommand(IAnsiConsole console, Card card, IEnemy enemy) : IBattleCommand
{
    public void Execute()
    {
        enemy.Health -= card.Attack;
    }
}
