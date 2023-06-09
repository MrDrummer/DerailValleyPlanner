namespace IndexedList.UnitTests;

public class IndexedTest
{
    private List<IndexedInstance> _indexedList { get; set; }
    
    private class IndexedInstance : Indexed {}
    
    [SetUp]
    public void Setup()
    {
        _indexedList = new List<IndexedInstance>
        {
            new()
            {
                Index = 1,
            },
            new()
            {
                Index = 3,
            },
            new()
            {
                Index = 0,
            },
            new()
            {
                Index = 2,
            },
        };
    }

    [Test]
    public void SortByIndex()
    {
        var toEqual = new List<IndexedInstance>
        {
            new()
            {
                Index = 0,
            },
            new()
            {
                Index = 1,
            },
            new()
            {
                Index = 2,
            },
            new()
            {
                Index = 3,
            },
        };
        
        _indexedList.Sort();
        
        Assert.Multiple(() =>
        {
            Assert.That(_indexedList[0].Index, Is.EqualTo(toEqual[0].Index));
            Assert.That(_indexedList[1].Index, Is.EqualTo(toEqual[1].Index));
            Assert.That(_indexedList[2].Index, Is.EqualTo(toEqual[2].Index));
            Assert.That(_indexedList[3].Index, Is.EqualTo(toEqual[3].Index));
        });
    }
}