namespace Common;

public interface ICardComponent
{
    bool IsComposite { get; }
    void Add(ICardComponent cardComponent);
    bool Remove(ICardComponent cardComponent);
    ICardComponent GetCardComponent(int index);
    string Display();
}
