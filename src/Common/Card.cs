namespace Common;

public class Card : ICardComponent
{
    protected readonly string _name;
    protected readonly int _attack;
    protected readonly int _defense;

    public Card(string name, int attack, int defense)
    {
        _name = name;
        _attack = attack;
        _defense = defense;
    }
    public virtual string Name => _name;
    public virtual int Attack => _attack;
    public virtual int Defense => _defense;
    public void Add(ICardComponent cardComponent)
    {
        throw new NotSupportedException("Cannot add to a card");
    }

    public bool Remove(ICardComponent cardComponent)
    {
        throw new NotSupportedException("Cannot remove from a card");
    }

    public ICardComponent GetCardComponent(int index)
    {
        throw new NotSupportedException("Cannot get from a card");
    }

    public string Display()
    {
        return $"{_name}: Attack: {_attack} Defense: {_defense}" + Environment.NewLine;
    }

    public bool IsComposite => false;
}
