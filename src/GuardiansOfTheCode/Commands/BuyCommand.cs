using GuardiansOfTheCode.Multiplayer;

namespace GuardiansOfTheCode.Commands;

// ReSharper disable once ClassNeverInstantiated.Global
public class BuyCommand(IAnsiConsole console, SubscriptionManager manager) : Command
{
    public override int Execute(CommandContext context)
    {

        while (true)
        {
            console.Clear();
            console.MarkupLineInterpolated($"The current subscription is {manager.CurrentState.Description}");
            var result = manager.CurrentState switch
            {
                TrialState trialState => HandleTrialState(trialState),
                ExpiredState expiredState => HandleExpiredState(expiredState),
                PaidState paidState => HandlePaidState(paidState),
                _ => true
            };
            if (result) break;
        }

        console.MarkupLineInterpolated($"The current subscription is {manager.CurrentState.Description}");
        console.MarkupLineInterpolated($"Goodbye!");
        return 0;
    }

    private bool HandlePaidState(PaidState paidState)
    {
        console.WriteLine($"{paidState.Description}");
        return true;
    }

    private bool HandleExpiredState(ExpiredState expiredState)
    {
        console.WriteLine($"{expiredState.Description}");
        var result = console.Prompt(
            new SelectionPrompt<string>()
                .Title("Would you like to buy this subscription?")
                .AddChoices("Yes", "No", "Maybe later")
            );
        return result switch
        {
            "Yes" => UpgradeSubscription(),
            "No" => UpdateTimeRemaining(),
            _ => true
        };
    }

    private bool UpgradeSubscription()
    {
        manager.Pay();
        return true;
    }

    private bool HandleTrialState(TrialState trialState)
    {
        console.WriteLine($"{trialState.Description}");
        var result = console.Prompt(
            new SelectionPrompt<string>()
                .Title("Would you like to buy this subscription?")
                .AddChoices("Yes", "No", "Maybe later")
            );
        return result switch
        {
            "Yes" => UpgradeSubscription(),
            _ => UpdateTimeRemaining(),
        };
    }

    private bool UpdateTimeRemaining()
    {
        manager.Expire();
        console.MarkupLineInterpolated($"Your trial has expired. You can buy the subscription to continue.");
        return false;
    }
}
