using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BHCustomNode : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt_Index;

    public int index;

    void Start()
    {
    }

    public void SetIndex(int index)
    {
        this.index = index;
        txt_Index.text = index.ToString();
    }

    public void Refresh()
    {
        txt_Index.text = index.ToString();
    }

}
