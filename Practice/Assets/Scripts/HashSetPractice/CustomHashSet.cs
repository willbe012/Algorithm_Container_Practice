using System;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using static UnityEditor.Experimental.GraphView.Port;

public class CustomHashSet<T>
{
    // HashSet 중복 요소 X 순서 X
    // 중복없이 뭔가 갯수를 구할 때 유용할 것 같은 느낌..
    // Dictionary랑 다른게 뭐지? => Value가 없음. Key들의 집합 같은 느낌.
    // 기본적으로 Add, Remove 필요. 중복을 허용하지 않으니 중복검사 Contains 추가.
    // 해시 코드를 배열의 길이로 모듈러 연산(%연산)하여 해당 버킷의 인덱스 결정.

    // T를 받으면 반드시 필요한건? => Equals와 GetHashCode() 재정의 해주는 것..!

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


    // 사용자가 Contains 함수를 쓸 이유가 없지 않을까? => private
    private bool Contains(T item) 
    {
        var index = GetIndex(item);

        if (buckets[index] != null && item.Equals(buckets[index]))
            return true; 

        return false;
    }

    // 예시로 int가 들어왔다고 생각해보면,, 겹치는게 분명히 나온다.
    // 겹치는 건 어쩔 수 없으니까 어떻게 해야할까?
    // => Contains에서 실제 item이 일치하는지도 확인하면 된다.

    private int GetIndex(T item)
    {
        var hashCode = item.GetHashCode();
        var index = hashCode % buckets.Length;
        return index;
    }

}