namespace GuardiansOfTheCode;

public sealed class PrimaryPlayer
{
    private PrimaryPlayer() {}

    public static PrimaryPlayer Instance { get; } = new PrimaryPlayer();

    public string Name { get; set; } = "Player 1";
    public int Level { get; set; } = 1;
}
