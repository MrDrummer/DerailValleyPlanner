namespace IndexedList;

public interface IIndexed : IComparable<Indexed>
{
    int Index { set; get; }
}