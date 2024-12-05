using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

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

    public static void MergeSort(int[] array)
    {
        // Divide and Conquer(분할 정복)
        // 문제를 작은 단위로 나누고 각각을 정렬한 뒤에 다시 합치는 방식.
        // Divide(분할) - 배열을 더이상 나뉘지 않을 때까지 절반으로 계속해서 나눈다. 재귀쓰면 될 듯?
        // Conquer(정복) - 나뉜 배열을 정렬한다. 배열의 크기가 만일 1이라면 이미 정렬된 녀석이니 내버려둔다.
        // Combine(합병) - 정렬된 배열을 하나로 합친다. 이 때 크기를 비교하고 작은 값을 먼저 병합해서 정렬된 배열을 만든다.
        // 시간복잡도 최악,최선 모두 O(n * logn) 
        // 배열을 logn 단계로 나누고(뎁스), 각 단계에서 병합하는 과정은 O(n)임. 즉 병합 * 뎁스 = n * log n

        if (array.Length <= 1)  // 종료 조건: 배열 길이가 1 이하일 경우 더 이상 나누지 않음
            return;

        // 나누게 될 기준 1,5,2,4,7,3,0,9
        var halfCount = array.Length / 2; // 4

        // 좌측 우측 배열 나누기
        int[] left = new int[halfCount]; // 1,5,2,4
        int[] right = new int[array.Length - halfCount]; // 7,3,0,9

        // 좌측 우측 배열에 기존 배열 값 넣어주기.
        for(int i = 0; i < halfCount; ++i)
            left[i] = array[i];

        for(int i = halfCount; i < array.Length; ++i)
            right[i - halfCount] = array[i];

        MergeSort(left);
        MergeSort(right);

        // 병합.
        Merge(array, left, right);
    }

    private static void Merge(int[] array, int[] left, int[] right)
    {
        // 두 개의 정렬된 배열을 하나의 정렬된 배열로 병합한다.
        int i = 0, j = 0, k = 0;


        // 1. 두 배열을 비교하며 병합.
        while(i < left.Length && j < right.Length)
        {
            // Depth 1
            // 1             // 5

            if (left[i] <= right[j])
            {
                
                // 좌측항이 더 작으면
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

        // 2. 왼쪽배열
        // 예시 배열에선 i가 이미 증가했으니 처음엔 여길 타지 않겠지.
        while(i < left.Length)
        {
            array[k] = left[i];
            ++i;
            ++k;
        }


        // 3. 오른쪽배열
        // 5
        while(j < right.Length)
        {
            array[k] = right[j];
            ++j;
            ++k;
        }


    }

    public static void MergeSort2(int[] array)
    {
        // 재귀 X 
        // 가장 작은 단위에서 큰 단위로 병합.  Bottom-Up
        // 그러면 최초 size가 1인 상태에서 시작을 해야한다.
        // 병합과정은 비슷함. 배열끼리 비교해서 정렬.
        // ex) 1 / 5 / 3 / 6  => 1,5 / 3,6 => 1,3,5,6

        // 최초의 작은 단위를 구하는 방법이 중요할 듯?
        // size가 *=2 씩 증가하는 이유는,, 1 -> 2 -> 4 -> 8... 정확히 절반씩 분열했던걸 반대로!

        // left = 왼쪽 부분 배열의 시작 인덱스
        // mid = 왼쪽 배열과 오른쪽 배열을 나누는 중간점
        // right = 배열의 끝


        if (array.Length <= 1) return;

        int n = array.Length;
        int[] temp = new int[n]; // 병합 결과 저장하는 임시 배열


        for (int size = 1; size < n; size *= 2)
        {
            for (int leftStart = 0; leftStart < n; leftStart += 2 * size)
            {
                // 병합할 두 부분 배열의 시작점과 끝점 계산
                int mid = Math.Min(leftStart + size, n); // 중간점
                int rightEnd = Math.Min(leftStart + 2 * size, n); // 끝점

                // 병합 수행
                Merge(array, temp, leftStart, mid, rightEnd);
            }
        }
    }

    private static void Merge(int[] array, int[] temp, int leftStart, int mid, int rightEnd)
    {
        int i = leftStart, j = mid, k = leftStart;

        // 두 부분 배열을 비교하여 병합
        while (i < mid && j < rightEnd)
        {
            if (array[i] <= array[j])
            {
                temp[k] = array[i];
                ++k;
                ++i;
            }
            else
            {
                temp[k] = array[j];
                ++k;
                ++j;
            }
        }

        while (i < mid)
        {
            temp[k] = array[i];
            ++k;
            ++i;
        }

        while (j < rightEnd)
        {
            temp[k] = array[j];
            ++k;
            ++j;
        }

        for (i = leftStart; i < rightEnd; i++)
        {
            array[i] = temp[i];
        }
    }


    // 문제: 주어진 동전들로 특정 금액을 만드는데 필요한 최소 동전 수를 구하는 함수를 작성하세요.

    // 그리디 알고리즘
    // 매 단계 현재 상황에서 최선의 선택을 하는 방식으로 문제 해결
    // 가장 큰 금액의 동전부터 사용하면 되겠다.

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
