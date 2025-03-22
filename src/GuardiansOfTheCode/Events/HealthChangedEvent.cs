namespace GuardiansOfTheCode.Events;

public class HealthChangedEventArgs: EventArgs
{
    public int Health { get; private set; }
    public int Damage { get; private set; }

    public HealthChangedEventArgs(int health, int damage)
    {
        Health = health;
        Damage = damage;
    }
}
