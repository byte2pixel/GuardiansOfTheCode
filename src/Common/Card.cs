namespace Common;

public class Card
{
    protected string _name;
    protected int _attack;
    protected int _defense;

    public Card(string name, int attack, int defense)
    {
        _name = name;
        _attack = attack;
        _defense = defense;
    }
    public virtual string Name => _name;
    public virtual int Attack => _attack;
    public virtual int Defense => _defense;
}
