using GuardiansOfTheCode.Enemies;
using GuardiansOfTheCode.Player;

namespace GuardiansOfTheCode.BattleCommands;

public class PlayerEnemyBattle(IAnsiConsole console, PrimaryPlayer player, IEnemy enemy)
    : IBattleCommand
{
    public void Execute()
    {
        PlayerAttacks();
        if (enemy.Health > 0)
        {
            EnemyAttacks();
        }
    }

    private void EnemyAttacks()
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
            console.MarkupLineInterpolated(
                $"[red]{enemy.Name}[/] attacks [red]{player.Name}[/] for [red]{damage}[/] damage!"
            );
            player.TakeDamage(damage);
        }
    }

    private void PlayerAttacks()
    {
        console.MarkupLineInterpolated(
            $"[green]{player.Name}[/] attacks [red]{enemy.Name}[/] with a [blue]{player.Weapon.Name}[/]"
        );
        player.Weapon.Use(console, enemy);

    }
}
