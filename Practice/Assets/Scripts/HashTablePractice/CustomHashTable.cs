using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CustomHashTable<TKey, TValue>
{
    // HashTable과 Dictionary가 다른게 뭘까? 둘다 Key Value를 사용해서 자료를 저장하는 것은 같다.
    // Dictionary는 선언할 때 타입을 미리 설정해야한다. 
    // CustomLinkedList로 구현해볼까

    private static readonly int initCapacity = 11; // prime num?

    private class CustomHashTablePair
    {
        public TKey key;
        public TValue value;
        public CustomHashTablePair(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }
    }

    private CustomLinkedList<CustomHashTablePair>[] pairs = new CustomLinkedList<CustomHashTablePair>[initCapacity];

    public void Add(TKey key, TValue value)
    {
        var idx = GetIndex(key);
        if (pairs[idx] == null)
        {
            pairs[idx] = new CustomLinkedList<CustomHashTablePair>();
        }

        var linkedList = pairs[idx];
        for(int i = 0; i < linkedList.GetCount(); ++i) 
        {
            var k = linkedList.Get(i);
            if(k.Equals(key))
            {
                linkedList.Get(i).value = value;
                return;
            }
        }

        var pair = new CustomHashTablePair(key, value);
        pairs[idx].AddElement(pair);
        return;
    }

    public void Remove(TKey key) 
    {
        var idx = GetIndex(key);

        if (pairs[idx] == null)
            return;

        var linkedList = pairs[idx];
        for (int i = 0; i < linkedList.GetCount(); ++i)
        {
            var pair = linkedList.Get(i);
            if (pair.key.Equals(key))
            {
                linkedList.RemoveElement(pair);
                return;
            }
        }
        return;
    }


    private int GetIndex(TKey key)
    {
        var hashCode = key.GetHashCode();
        var index = hashCode % pairs.Length;
        return index;
    }

}
