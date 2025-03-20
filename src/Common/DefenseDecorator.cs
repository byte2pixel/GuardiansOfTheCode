namespace Common;

public class DefenseDecorator : CardDecorator
{
    public DefenseDecorator(Card card, string name, int defense) : base(card, name, 0, defense)
    {
        _card = card;
    }
    public override string Name => $"{_card.Name}, {_name}";
    public override int Defense => _card.Defense + _defense;
}
