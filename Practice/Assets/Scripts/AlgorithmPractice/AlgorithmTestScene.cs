using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlgorithmTestScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt_array;
    int[] array = new int[12];

    void Start()
    {
        for(int i = 0 ; i < array.Length; ++i)
            array[i] = UnityEngine.Random.Range(0, 100);

        //Algorithms.MergeSort(array);

        for(int i = 0; i < array.Length; ++i) 
            txt_array.text += array[i] + ", ";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Algorithms.MergeSort(array);

            txt_array.text = string.Empty;

            for (int i = 0; i < array.Length; ++i)
                txt_array.text += array[i] + ", ";
        }


    }
}
