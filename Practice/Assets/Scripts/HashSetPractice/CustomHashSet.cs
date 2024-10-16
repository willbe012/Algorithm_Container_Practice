using System;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using static UnityEditor.Experimental.GraphView.Port;

public class CustomHashSet<T>
{
    // HashSet �ߺ� ��� X ���� X
    // �ߺ����� ���� ������ ���� �� ������ �� ���� ����..
    // Dictionary�� �ٸ��� ����? => Value�� ����. Key���� ���� ���� ����.
    // �⺻������ Add, Remove �ʿ�. �ߺ��� ������� ������ �ߺ��˻� Contains �߰�.
    // �ؽ� �ڵ带 �迭�� ���̷� ��ⷯ ����(%����)�Ͽ� �ش� ��Ŷ�� �ε��� ����.

    // T�� ������ �ݵ�� �ʿ��Ѱ�? => Equals�� GetHashCode() ������ ���ִ� ��..!

    private int capacity;
    private T[] buckets;
    private int size;

    CustomHashSet()
    {
        size = 0;
        capacity = 11;
        buckets = new T[capacity];
    }

    public void Add(T item)
    {
        if (Contains(item) == true)
            return;

        var index = GetIndex(item);
        buckets[index] = item;

        size++;
    }

    public void Remove(T item)
    {
        var index = GetIndex(item);
        buckets[index] = default;
        size--;
    }


    // ����ڰ� Contains �Լ��� �� ������ ���� ������? => private
    private bool Contains(T item) 
    {
        var index = GetIndex(item);

        if (buckets[index] != null && item.Equals(buckets[index]))
            return true; 

        return false;
    }

    // ���÷� int�� ���Դٰ� �����غ���,, ��ġ�°� �и��� ���´�.
    // ��ġ�� �� ��¿ �� �����ϱ� ��� �ؾ��ұ�?
    // => Contains���� ���� item�� ��ġ�ϴ����� Ȯ���ϸ� �ȴ�.

    private int GetIndex(T item)
    {
        var hashCode = item.GetHashCode();
        var index = hashCode % buckets.Length;
        return index;
    }

}