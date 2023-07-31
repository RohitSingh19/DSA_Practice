public class MyHashSet
{
    int[] hash;
    int index = 0;
    public MyHashSet()
    {
        hash = new int[1000000];
    }

    public void Add(int key)
    {
        int idx = FindKey(key);
        if (idx != -1) return;
        hash[index++] = key;
    }

    public void Remove(int key)
    {
        int idx = FindKey(key);
        if (idx == -1) return;
        hash[idx] = -1;
        idx--;
    }

    public bool Contains(int key)
    {
        return (FindKey(key) != -1);
    }

    private int FindKey(int key)
    {
        int idx = 0;
        while (idx < index)
        {
            if (hash[idx++] == key) return idx;
        }
        return -1;
    }

}

