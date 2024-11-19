using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

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

    public static void MergeSort(int[] array)
    {
        // Divide and Conquer(���� ����)
        // ������ ���� ������ ������ ������ ������ �ڿ� �ٽ� ��ġ�� ���.
        // Divide(����) - �迭�� ���̻� ������ ���� ������ �������� ����ؼ� ������. ��;��� �� ��?
        // Conquer(����) - ���� �迭�� �����Ѵ�. �迭�� ũ�Ⱑ ���� 1�̶�� �̹� ���ĵ� �༮�̴� �������д�.
        // Combine(�պ�) - ���ĵ� �迭�� �ϳ��� ��ģ��. �� �� ũ�⸦ ���ϰ� ���� ���� ���� �����ؼ� ���ĵ� �迭�� �����.
        // �ð����⵵ �־�,�ּ� ��� O(n * logn) 
        // �迭�� logn �ܰ�� ������(����), �� �ܰ迡�� �����ϴ� ������ O(n)��. �� ���� * ���� = n * log n

        if (array.Length <= 1)  // ���� ����: �迭 ���̰� 1 ������ ��� �� �̻� ������ ����
            return;

        // ������ �� ���� 1,5,2,4,7,3,0,9
        var halfCount = array.Length / 2; // 4

        // ���� ���� �迭 ������
        int[] left = new int[halfCount]; // 1,5,2,4
        int[] right = new int[array.Length - halfCount]; // 7,3,0,9

        // ���� ���� �迭�� ���� �迭 �� �־��ֱ�.
        for(int i = 0; i < halfCount; ++i)
            left[i] = array[i];

        for(int i = halfCount; i < array.Length; ++i)
            right[i - halfCount] = array[i];

        MergeSort(left);
        MergeSort(right);

        // ����.
        Merge(array, left, right);
    }

    private static void Merge(int[] array, int[] left, int[] right)
    {
        // �� ���� ���ĵ� �迭�� �ϳ��� ���ĵ� �迭�� �����Ѵ�.
        int i = 0, j = 0, k = 0;


        // 1. �� �迭�� ���ϸ� ����.
        while(i < left.Length && j < right.Length)
        {
            // Depth 1
            // 1             // 5

            if (left[i] <= right[j])
            {
                
                // �������� �� ������
                // 1
                array[k] = left[i];
                ++i;
            }
            else
            {
                array[k] = right[j];
                ++j;
            }
            ++k;
        }

        // 2. ���ʹ迭
        // ���� �迭���� i�� �̹� ���������� ó���� ���� Ÿ�� �ʰ���.
        while(i < left.Length)
        {
            array[k] = left[i];
            ++i;
            ++k;
        }


        // 3. �����ʹ迭
        // 5
        while(j < right.Length)
        {
            array[k] = right[j];
            ++j;
            ++k;
        }


    }


    // ����: �־��� ������� Ư�� �ݾ��� ����µ� �ʿ��� �ּ� ���� ���� ���ϴ� �Լ��� �ۼ��ϼ���.

    // �׸��� �˰���
    // �� �ܰ� ���� ��Ȳ���� �ּ��� ������ �ϴ� ������� ���� �ذ�
    // ���� ū �ݾ��� �������� ����ϸ� �ǰڴ�.

    public static int MinCoins(int[] coins, int amount)
    {
        MergeSort(coins);
        coins.Reverse();
        int count = 0;

        for (int i = 0; i < coins.Length; ++i)
        {
            while (amount >= coins[i])
            {
                amount -= coins[i];  
                count++;              
            }
        }

        if (amount > 0)
            return -1; 

        return count;
    }
}
