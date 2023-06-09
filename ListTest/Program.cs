using System.Collections.ObjectModel;

var list = new ObservableCollection<Indexed>();
for (var i = 0; i < 10; i++)
{
    var item = new Indexed { Index = i };
    item.PropertyChanging += ItemOnPropertyChanging;
    list.Add(item);
}

list.Move(0, 1);

list[0].Index = 1;
list[1].Index = 0;

Thread.Sleep(2000);

static void ItemOnPropertyChanging(object? sender, ValueChanged e)
{
    Console.WriteLine($"{e.OldValue} changed to ${e.NewValue}");
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