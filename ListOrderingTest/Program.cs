// Example:
// 1. Item 1
// 2. Item 2
// 3. Item 3
// 4. Item 4
//
// If I want to move Item 1 after Item 2:
// 
// 1. Item 2
// 2. Item 1
// 3. Item 3
// 4. Item 4
//
// I will then need to update both Item 1 and Item 2 to have a new Index value,
// so that when it's sorted again, it's in the new order.


using System.Text.Json;

var list = new ManagedList<Example>
{
    new()
    {
        Key = 1,
        Index = 1,
    },
    new()
    {
        Key = 2,
        Index = 3,
    },
    new()
    {
        Key = 3,
        Index = 0,
    },
    new()
    {
        Key = 4,
        Index = 2,
    },
    new()
    {
        Key = 5,
        Index = 4,
    }
};

var beforeSort = JsonSerializer.Serialize(list);
Console.WriteLine($"Before Sort: {beforeSort}");

list.Sort();

var afterSort = JsonSerializer.Serialize(list);
Console.WriteLine($"After Sort/Before Move: {afterSort}");


list.Move(0, 1);

for (var i = 0; i < list.Count; i++)
{
    var item = list[i];
    if (item.Index == i) continue;
    item.Index = i;
}


var afterOutput = JsonSerializer.Serialize(list);

Console.WriteLine($"After Move: {afterOutput}");


internal class Example : IComparable<Example>
{
    // Never changes
    public int Key { set; get; }

    // Dynamically changed and updated in DB whenever position within the list is changed
    public int Index { set; get; }

    public int CompareTo(Example? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Index.CompareTo(other.Index);
    }
}

internal class ManagedList<T> : List<T>
{
    public void Move(int fromIndex, int toIndex)
    {
        var itemBeingMoved = this[fromIndex];
        RemoveAt(fromIndex);
        Insert(toIndex, itemBeingMoved);
    }
}