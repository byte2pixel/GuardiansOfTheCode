using GuardiansOfTheCode.Player;
using GuardiansOfTheCode.Strategies;

namespace GuardiansOfTheCode.Events;

public class PlayerHealthListener(IDamageIndicator strategy)
{
    public void OnPlayerHealthChanged(PrimaryPlayer player)
    {
        player.Subscribe(Handler);
    }

    private void Handler(object? sender, HealthChangedEventArgs e)
    {
        strategy.NotifyAboutDamage(e.Health, e.Damage);
    }
}
