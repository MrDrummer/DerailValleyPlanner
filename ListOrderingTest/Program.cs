var myList = new ManagedList<Example>
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
        Index = 5,
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
    },
};


myList.Sort((e1, e2) => e1.Index.CompareTo(e2.Index));
foreach (var el in myList)
{
    Console.WriteLine("ORIGINAL ORDER: Key: {0}, Index: {1}", el.Key, el.Index);
}


// 0     2
// V     V
// 1, 4, 2, 5, 3
// TO
// 2, 1, 4, 5, 3
// var affectedElements = myList.Move(0, 2);

//       2     4
//       V     V
// 1, 4, 2, 5, 3
// TO
// 1, 4, 5, 3, 2
// var affectedElements = myList.Move(2, 4);


// 0           4
// V           V
// 1, 4, 2, 5, 3
// TO
// 4, 2, 5, 3, 1
// var affectedElements = myList.Move(0, 4);


//    1        4
//    V        V
// 1, 4, 2, 5, 3
// TO
// 1, 2, 5, 3, 4
// var affectedElements = myList.Move(1, 4);

//    1        4
//    V        V
// 1, 4, 2, 5, 3
// TO
// 1, 3, 4, 2, 5
var affectedElements = myList.Move(4, 1);

for (var i = 0; i < affectedElements.Count; i++)
{
    var el = affectedElements[i];
    
    // TODO: I think this - 1 may be + 1 if toIndex is greater than fromIndex
    el.Index = (i + 1) + 0; // <- fromIndex (first arg sent to ManagedList.Move)
}

foreach (var el in affectedElements)
{
    Console.WriteLine("AFFECTED: Key: {0}, Index: {1}", el.Key, el.Index);
}
foreach (var el in myList)
{
    Console.WriteLine("NEW ORDER: Key: {0}, Index: {1}", el.Key, el.Index);
}

internal class ManagedList<T> : List<T>
{
    public ManagedList<T> Move(int fromIndex, int toIndex)
    {
        var output = new ManagedList<T>();
        var itemBeingMoved = this[fromIndex];
        RemoveAt(fromIndex);
        Insert(toIndex, itemBeingMoved);
        

        // TODO: Fix assumption that fromIndex is always less than toIndex
        for (var i = fromIndex; i <= toIndex; i++)
        {
            var obj = this[i];
            
            // var property = obj?.GetType().GetProperty("Index");
            //
            // var currentValue = property?.GetValue(obj, null);
            //
            // Console.WriteLine("currentValue: {0}", currentValue);
            //
            // if (currentValue == null || property == null) continue;
            //
            // property.SetValue(obj, (int)currentValue + 1 + fromIndex);
            
            output.Add(obj);
        }

        return output;
    }
}


internal class Example
{
    // Never changes
    public int Key { set; get; }
    
    // Dynamically changed and updated in DB whenever position changed
    public int Index { set; get; }
}