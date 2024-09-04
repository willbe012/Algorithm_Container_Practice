using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YYY;

public class CustomLinkedListSceneGameManager : MonoBehaviour
{
    #region inspector
    [SerializeField] Button btn_GenerateNode;
    [SerializeField] Button btn_DestroyNode;
    [SerializeField] Transform trans_NodePivot;
    [SerializeField] TMP_InputField txt_inputField;
    #endregion


    #region variables
    CustomLinkedList<BHCustomNode> list = new CustomLinkedList<BHCustomNode>();
    #endregion



    #region overriden Methods
    void Start()
    {
        btn_GenerateNode.onClick.AddListener(OnClickGenerateNode);
        btn_DestroyNode.onClick.AddListener(OnClickDestroyNode);
    }
    #endregion

    #region private methods

    #endregion

    void RefreshNodes()
    {
        for(int i = 0; i < list.GetCount(); ++i)
        {
            list.Get(i).Refresh();
        }
    }


    #region callBack

    void OnClickGenerateNode()
    {
        var clone = Resources.Load<BHCustomNode>("LinkedListPractice/CustomNode");
        if (clone == null)
            return;

        var node = Instantiate(clone, trans_NodePivot);
        if (node == null)
            return;

        var txt = txt_inputField.text;
        var idx = int.Parse(txt);

        node.SetIndex(idx);
        list.AddElement(node);

        RefreshNodes();
    }
    void OnClickDestroyNode()
    {
        var txt = txt_inputField.text;
        var RemoveIdx = int.Parse(txt);
        var value = list.Get(RemoveIdx);

        list.RemoveElement(value);

        RefreshNodes();
    }

    #endregion
}
