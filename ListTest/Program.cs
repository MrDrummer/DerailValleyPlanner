using System.Collections.ObjectModel;
using System.Collections.Specialized;

var list = new ObservableCollection<Indexed>();
list.CollectionChanged += (sender, args) =>
{
    if (args.Action != NotifyCollectionChangedAction.Move) return;
    Console.WriteLine($"Item at index {args.OldStartingIndex} moved to index {args.NewStartingIndex}");

    var (oldI, newI) = (args.OldStartingIndex, args.NewStartingIndex);

    var start = newI > oldI ? oldI : newI;

    if (sender is not ObservableCollection<Indexed> newItems || newItems.Count == 0) return;
    for (var i = start; i < newItems.Count; i++)
    {
        var item = newItems[i];

        if (item != null && item.Index == i) return;
        
        
        item.Index = i;
    }
};

for (var i = 0; i < 10; i++)
{
    var item = new Indexed { Index = i, Original = i };
    item.PropertyChanging += ItemOnPropertyChanging;
    list.Add(item);
}

list.Move(0, 3);
list.Move(9, 3);

Thread.Sleep(2000);

static void ItemOnPropertyChanging(object? sender, ValueChanged e)
{
    Console.WriteLine($"{e.OldValue} changed to {e.NewValue}");
}

public struct ValueChanged
{
    public object OldValue { get; init; }
    public object NewValue { get; init; }

    public ValueChanged(object oldValue, object newValue) => (OldValue, NewValue) = (oldValue, newValue);
}

public class Indexed
{
    private int _index;

    public delegate void ValueChangedEventHandler(object? sender, ValueChanged e);

    public event ValueChangedEventHandler? PropertyChanging;
    
    public int Original { get; set; }
    
    public int Index
    {
        get => _index;
        set
        {
            PropertyChanging?.Invoke(this, new ValueChanged(_index, value));
            _index = value;
        }
    }
}