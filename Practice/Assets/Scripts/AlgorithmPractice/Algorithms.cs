using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Algorithms
{
    // �ð� ���⵵ ���
    // ��� ǥ���
    // 1. ����� ����
    // 2. ����� ���� �� ����

    // n(n-1) / 2 = (n2 - n) / 2
    // O(n2)

    public static int[] BubbleSort(int[] array)
    {
        for(int i = 0; i < array.Length - 1; ++i)
        {
            for(int j = 0; j < array.Length - 1; ++j)
            {
                if (array[j] < array[j + 1])
                {
                    var temp = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
            }
        }
        return array;
    }

    public static int BinarySearch(int[] array, int findingValue)
    {
        // ���� Ž��.
        // �迭�� ���ĵǾ� ���� ��� ����ϴ� �˰���.
        // �߾Ӱ��̶� ���ؼ� Ž�� ������ ������ ����.
        // ��ü ������ N�� -> �ѹ� Ž�� N/2 -> �ι�° (N/2) / 2 -> ����° ((n/2) / 2) /  2....
        // i��° Ž�� N * ((1/2)^i)    (2^i = N)   i = log2^N 

        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == findingValue)
                return mid;
            else if (array[mid] < findingValue)
                left = mid + 1;
            else
                right = mid - 1;
        }

        // ��ã����!!
        return -1;
    }



}
