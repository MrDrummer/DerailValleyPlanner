namespace IndexedList.UnitTests;

public class IndexedListTest
{
    private IndexedList<IndexedInstance> _indexedList { get; set; }

    private class IndexedInstance : Indexed
    {
        public int Key { get; set; }
    }
    
    [SetUp]
    public void Setup()
    {
        _indexedList = new IndexedList<IndexedInstance>
        {
            new()
            {
                Index = 0,
                Key = 0
            },
            new()
            {
                Index = 1,
                Key = 1
            },
            new()
            {
                Index = 2,
                Key = 2
            },
            new()
            {
                Index = 3,
                Key = 3
            },
        };
    }

    [Test]
    public void Sort()
    {
        var before = new IndexedList<IndexedInstance>
        {
            new()
            {
                Index = 0,
                Key = 0
            },
            new()
            {
                Index = 2,
                Key = 2
            },
            new()
            {
                Index = 1,
                Key = 1
            },
            new()
            {
                Index = 3,
                Key = 3
            },
        };
        
        before.Sort();
        
        Assert.Multiple(() =>
        {
            Assert.That(before[0].Index, Is.EqualTo(_indexedList[0].Index));
            Assert.That(before[1].Index, Is.EqualTo(_indexedList[1].Index));
            Assert.That(before[2].Index, Is.EqualTo(_indexedList[2].Index));
            Assert.That(before[3].Index, Is.EqualTo(_indexedList[3].Index));
        });
    }

    [Test]
    public void MoveForwards()
    {
        var toEqual = new IndexedList<IndexedInstance>
        {
            new()
            {
                Index = 0,
                Key = 0
            },
            new()
            {
                Index = 2,
                Key = 2
            },
            new()
            {
                Index = 1,
                Key = 1
            },
            new()
            {
                Index = 3,
                Key = 3
            },
        };
        
        _indexedList.Move(1, 2);
        
        Assert.Multiple(() =>
        {
            Assert.That(_indexedList[0].Index, Is.EqualTo(toEqual[0].Index));
            Assert.That(_indexedList[1].Index, Is.EqualTo(toEqual[1].Index));
            Assert.That(_indexedList[2].Index, Is.EqualTo(toEqual[2].Index));
            Assert.That(_indexedList[3].Index, Is.EqualTo(toEqual[3].Index));
        });
    }

    [Test]
    public void MoveBackwards()
    {
        var toEqual = new IndexedList<IndexedInstance>
        {
            new()
            {
                Index = 0,
                Key = 0
            },
            new()
            {
                Index = 2,
                Key = 2
            },
            new()
            {
                Index = 1,
                Key = 1
            },
            new()
            {
                Index = 3,
                Key = 3
            },
        };
        
        _indexedList.Move(2, 1);
        
        Assert.Multiple(() =>
        {
            Assert.That(_indexedList[0].Index, Is.EqualTo(toEqual[0].Index));
            Assert.That(_indexedList[1].Index, Is.EqualTo(toEqual[1].Index));
            Assert.That(_indexedList[2].Index, Is.EqualTo(toEqual[2].Index));
            Assert.That(_indexedList[3].Index, Is.EqualTo(toEqual[3].Index));
        });
    }

    [Test]
    public void MoveForwardsUpdateIndex()
    {
        var toEqual = new IndexedList<IndexedInstance>
        {
            new()
            {
                Index = 0,
                Key = 0
            },
            new()
            {
                Index = 1,
                Key = 1
            },
            new()
            {
                Index = 2,
                Key = 3
            },
            new()
            {
                Index = 3,
                Key = 2
            },
        };
        
        _indexedList.Move(3, 2);
        
        Assert.Multiple(() =>
        {
            Assert.That(_indexedList[0].Index, Is.EqualTo(0));
            Assert.That(_indexedList[1].Index, Is.EqualTo(1));
            Assert.That(_indexedList[2].Index, Is.EqualTo(3));
            Assert.That(_indexedList[3].Index, Is.EqualTo(2));
        });

        var updates = 0;
        
        _indexedList.ActionOnUpdatedIndex(i => updates++);
        
        Assert.That(updates, Is.EqualTo(2));
        
        Assert.Multiple(() =>
        {
            Assert.That(_indexedList[0].Index, Is.EqualTo(toEqual[0].Index));
            Assert.That(_indexedList[1].Index, Is.EqualTo(toEqual[1].Index));
            Assert.That(_indexedList[2].Index, Is.EqualTo(toEqual[2].Index));
            Assert.That(_indexedList[3].Index, Is.EqualTo(toEqual[3].Index));
        });
        
        Assert.Multiple(() =>
        {
            Assert.That(_indexedList[0].Key, Is.EqualTo(toEqual[0].Key));
            Assert.That(_indexedList[1].Key, Is.EqualTo(toEqual[1].Key));
            Assert.That(_indexedList[2].Key, Is.EqualTo(toEqual[2].Key));
            Assert.That(_indexedList[3].Key, Is.EqualTo(toEqual[3].Key));
        });
    }

    [Test]
    public void MoveBackwardsUpdateIndex()
    {
        var toEqual = new IndexedList<IndexedInstance>
        {
            new()
            {
                Index = 0,
                Key = 1
            },
            new()
            {
                Index = 1,
                Key = 2
            },
            new()
            {
                Index = 2,
                Key = 3
            },
            new()
            {
                Index = 3,
                Key = 0
            },
        };
        
        _indexedList.Move(0, 3);
        
        Assert.Multiple(() =>
        {
            Assert.That(_indexedList[0].Index, Is.EqualTo(1));
            Assert.That(_indexedList[1].Index, Is.EqualTo(2));
            Assert.That(_indexedList[2].Index, Is.EqualTo(3));
            Assert.That(_indexedList[3].Index, Is.EqualTo(0));
        });

        var updates = 0;
        
        _indexedList.ActionOnUpdatedIndex(i => updates++);
        
        Assert.That(updates, Is.EqualTo(4));
        
        Assert.Multiple(() =>
        {
            Assert.That(_indexedList[0].Index, Is.EqualTo(toEqual[0].Index));
            Assert.That(_indexedList[1].Index, Is.EqualTo(toEqual[1].Index));
            Assert.That(_indexedList[2].Index, Is.EqualTo(toEqual[2].Index));
            Assert.That(_indexedList[3].Index, Is.EqualTo(toEqual[3].Index));
        });
        
        Assert.Multiple(() =>
        {
            Assert.That(_indexedList[0].Key, Is.EqualTo(toEqual[0].Key));
            Assert.That(_indexedList[1].Key, Is.EqualTo(toEqual[1].Key));
            Assert.That(_indexedList[2].Key, Is.EqualTo(toEqual[2].Key));
            Assert.That(_indexedList[3].Key, Is.EqualTo(toEqual[3].Key));
        });
    }
}