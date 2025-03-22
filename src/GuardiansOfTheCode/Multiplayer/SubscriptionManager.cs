namespace GuardiansOfTheCode.Multiplayer;

public class SubscriptionManager
{
    public SubscriptionManager(IAnsiConsole console)
    {
        CurrentState = new TrialState(console, this);
    }

    public IState CurrentState { get; set; }

    public void Expire()
    {
        CurrentState.Expire();
    }

    public void Pay()
    {
        CurrentState.Pay();
    }
}
