namespace GuardiansOfTheCode.Multiplayer;

#pragma warning disable CS9113 // Parameter is unread.
public class PaidState(IAnsiConsole console, SubscriptionManager manager) : IState
#pragma warning restore CS9113 // Parameter is unread.
{
    public string Description => "Subscription is paid.";
    public void Expire()
    {
        // no-op
    }

    public void Pay()
    {
        // no-op
    }
}
