using Common;
using GuardiansOfTheCode.Enemies;

namespace GuardiansOfTheCode.BattleCommands;

public class CardEnemyBattleCommand(IAnsiConsole console, Card card, IEnemy enemy) : IBattleCommand
{
    public void Execute()
    {
        console.MarkupLineInterpolated($"The card [green]{card.Name}[/] deals [red]{card.Attack}[/] damage to the [red]{enemy.Name}[/].");
        var damage = Math.Min(enemy.Health, card.Attack);
        enemy.Health -= damage;
        enemy.DamageIndicator.NotifyAboutDamage(enemy.Health, damage);
    }
}
