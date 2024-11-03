using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Algorithms
{
    // 시간 복잡도 계산
    // 빅오 표기법
    // 1. 상수항 무시
    // 2. 영향력 없는 항 무시

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
        // 이진 탐색.
        // 배열이 정렬되어 있을 경우 사용하는 알고리즘.
        // 중앙값이랑 비교해서 탐색 범위를 반으로 줄임.
        // 전체 데이터 N개 -> 한번 탐색 N/2 -> 두번째 (N/2) / 2 -> 세번째 ((n/2) / 2) /  2....
        // i번째 탐색 N * ((1/2)^i)    (2^i = N)   i = log2^N 

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

        // 못찾았음!!
        return -1;
    }



}
