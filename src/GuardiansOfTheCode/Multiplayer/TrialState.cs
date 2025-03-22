namespace GuardiansOfTheCode.Multiplayer;

public class TrialState(IAnsiConsole console, SubscriptionManager manager) : IState
{
    public string Description => "Trial subscription.";
    public void Expire()
    {
        console.MarkupLine("Your trial has expired. Please pay to continue using the software.");
        manager.CurrentState = new ExpiredState(console, manager);
    }

    public void Pay()
    {
        console.MarkupLine("Paid membership acquired. Thank you for your support.");
        manager.CurrentState = new PaidState(console, manager);
    }
}
