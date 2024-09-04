//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class BHCustomNode : MonoBehaviour
//{
//    [SerializeField] Button btn_DestroyNode;
//    [SerializeField] TextMeshProUGUI txt_Index;
//    CustomLinkedListSceneGameManager manager;
//    public int index;

//    void Start()
//    {
//        btn_DestroyNode.onClick.AddListener(OnClickDestroyNode);
//    }

//    public void SetIndex(int index, CustomLinkedListSceneGameManager manager)
//    {
//        this.index = index;
//        txt_Index.text = index.ToString();
//        this.manager = manager;
//    }

//    public void Refresh()
//    {
//        txt_Index.text = index.ToString();
//    }

//    void OnClickDestroyNode()
//    {
//        manager.DestroyNode(index);
//        Destroy(this.gameObject);
//    }

//}
