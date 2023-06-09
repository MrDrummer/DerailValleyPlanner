namespace IndexedList;

public abstract class Indexed : IIndexed
{
    public int Index { set; get; }
    public int CompareTo(Indexed? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Index.CompareTo(other.Index);
    }
}