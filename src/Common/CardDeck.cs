using System.Text;

namespace Common;

public class CardDeck : ICardComponent
{
    private readonly List<ICardComponent> _components = [];

    public bool IsComposite => true;

    public void Add(ICardComponent cardComponent)
    {
        _components.Add(cardComponent);
    }

    public bool Remove(ICardComponent cardComponent)
    {
        return _components.Remove(cardComponent);
    }

    public ICardComponent GetCardComponent(int index)
    {
        return _components[index];
    }

    public string Display()
    {
        var builder = new StringBuilder();
        foreach (var component in _components)
        {
            builder.Append(component.Display());
        }

        return builder.ToString();
    }
}
