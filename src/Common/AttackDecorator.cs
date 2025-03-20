namespace Common;

public class AttackDecorator : CardDecorator
{
    public AttackDecorator(Card card, string name, int attack) : base(card, name, attack, 0)
    {
        _card = card;
    }
    public override string Name => $"{_card.Name}, {_name}";
    public override int Attack => _card.Attack + _attack;
}
