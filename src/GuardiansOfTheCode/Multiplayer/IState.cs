namespace GuardiansOfTheCode.Multiplayer;

public interface IState
{
    void Expire();
    void Pay();
    string Description { get; }
}
