using System;
using System.Collections;
using UnityEngine;


namespace YYY
{
    public class CustomQueue : MonoBehaviour
    {
        // Queue -> FIFO

        ArrayList arrayList = new ArrayList();

        void Queue<T>(T element)
        {
            arrayList.Add(element);
        }

        void DeQueue<T>(T element)
        {
            arrayList.RemoveAt(arrayList.Count - 1);
        }

    }
}
