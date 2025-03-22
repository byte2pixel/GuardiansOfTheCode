using Common;
using GuardiansOfTheCode.Events;
using GuardiansOfTheCode.Strategies;

namespace GuardiansOfTheCode.Player;

public sealed class PrimaryPlayer
{
    public PrimaryPlayer(IAnsiConsole console)
    {
        var normalDamageListener = new PlayerHealthListener(new RegularDamageIndicator(console, Name));
        var criticalDamageListener = new PlayerHealthListener(new CriticalHealthIndicator(console, Name));
        normalDamageListener.OnPlayerHealthChanged(this);
        criticalDamageListener.OnPlayerHealthChanged(this);
    }

    public string Name { get; set; } = "Player 1";
    public int Level { get; set; } = 1;
    public int Health { get; private set; } = 100;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        OnHealthChanged?.Invoke(this, new HealthChangedEventArgs(Health, damage));
    }

    public int Armor { get; set; } = 10;
    public IWeapon Weapon { get; set; } = new Sword(10, 5);
    public IEnumerable<Card> Cards { get; set; } = [];

    private event EventHandler<HealthChangedEventArgs>? OnHealthChanged;
    public void Subscribe(EventHandler<HealthChangedEventArgs>? handler) => OnHealthChanged += handler;
    public void Unsubscribe(EventHandler<HealthChangedEventArgs> handler) => OnHealthChanged -= handler;
}
