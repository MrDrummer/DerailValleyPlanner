using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.Json;

var list = new ManagedObservableCollection<Example>
{
    new()
    {
        Key = 1,
        Index = 1,
        Name = "Item 2",
    },
    new()
    {
        Key = 2,
        Index = 3,
        Name = "Item 4",
    },
    new()
    {
        Key = 3,
        Index = 0,
        Name = "Item 1",
    },
    new()
    {
        Key = 4,
        Index = 2,
        Name = "Item 3",
    },
    new()
    {
        Key = 5,
        Index = 4,
        Name = "Item 5",
    }
};

var beforeSort = JsonSerializer.Serialize(list);
Console.WriteLine($"Before Sort: {beforeSort}");

list.Sort();

var afterSort = JsonSerializer.Serialize(list);
Console.WriteLine($"Before Sort: {afterSort}");

list.CollectionChanged += (sender, args) =>
{
    if (args.Action != NotifyCollectionChangedAction.Replace) return;
    Console.WriteLine($"Item at index {args.OldStartingIndex} to index {args.NewStartingIndex}");
    
    var afterOutput = JsonSerializer.Serialize(list[args.NewStartingIndex]);

    Console.WriteLine($"ITEM UPDATED: {afterOutput}");
};


list.Move(0, 1);

for (var i = 0; i < list.Count; i++)
{
    var item = list[i];
    if (item.Index == i) continue;
    var newItem = (Example)item.Clone();
    newItem.Index = i;
    list[i] = newItem;
}


var afterOutput = JsonSerializer.Serialize(list);

Console.WriteLine($"After Move: {afterOutput}");


internal class Example : IComparable<Example>, ICloneable
{
    // Never changes
    public int Key { set; get; }

    // Dynamically changed and updated in DB whenever position changed
    public int Index { set; get; }
    public string Name { set; get; }

    public int CompareTo(Example? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Index.CompareTo(other.Index);
    }
    
    #region ICloneable Members

    public object Clone()
    {
        return MemberwiseClone();
    }

    #endregion
}

internal class ManagedObservableCollection<T> : ObservableCollection<T>
{
    public void Sort()
    {
        var index = 0;
        foreach (var item in this.Order())
        {
            var oldIndex = IndexOf(item);
            if (oldIndex != index)
            {
                MoveItem(oldIndex, index);
            }

            index++;
        }
    }
}