namespace DerailValleyPlanner.Models;

public struct ValueChanged
{
    public object OldValue { get; init; }
    public object NewValue { get; init; }

    public ValueChanged(object oldValue, object newValue) => (OldValue, NewValue) = (oldValue, newValue);
}

public class Indexed
{
    private int _index;

    public delegate void ValueChangedEventHandler(object sender, ValueChanged e);

    public event ValueChangedEventHandler PropertyChanging;
    
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