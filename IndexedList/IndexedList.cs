namespace IndexedList;

public class IndexedList<T> : List<T> where T: Indexed
{
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