namespace GuardiansOfTheCode.Multiplayer;

public class ExpiredState(IAnsiConsole console, SubscriptionManager manager) : IState
{
    public string Description => "Subscription expired.";
    public void Expire()
    {
        // no-op
    }

    public void Pay()
    {
        console.MarkupLine("Thank you for your payment. Your subscription is now active.");
        manager.CurrentState = new PaidState(console, manager);
    }
}
