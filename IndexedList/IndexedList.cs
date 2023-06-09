﻿namespace IndexedList;

// TODO: Investigate ListExtensions to add methods to the List class, rather than adding a layer.
public class IndexedList<T> : List<T> where T: IIndexed
{
    public IndexedList() {}
    public IndexedList(List<T> items)
    {
        AddRange(items);
    }
    
    public void Move(int fromIndex, int toIndex)
    {
        var itemBeingMoved = this[fromIndex];
        RemoveAt(fromIndex);
        Insert(toIndex, itemBeingMoved);
    }

    public void ActionOnUpdatedIndex(Action<T> callback)
    {
        for (var i = 0; i < Count; i++)
        {
            var item = this[i];
            if (item.Index == i) continue;
            item.Index = i;
            callback.Invoke(item);
        }
    }
}