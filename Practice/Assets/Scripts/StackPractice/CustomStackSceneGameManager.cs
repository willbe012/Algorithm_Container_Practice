using UnityEngine;
using UnityEngine.UI;
using YYY;

public class CustomStackSceneGameManager : MonoBehaviour
{
    #region inspector
    [SerializeField] Button btn_GenerateStackBox;
    [SerializeField] Button btn_DestroyStackBox;
    [SerializeField] Transform trans_StackBoxPivot;
    #endregion


    #region variables
    CustomStack<StackBox> stackBoxes = new CustomStack<StackBox>();
    #endregion



    #region overriden Methods
    void Start()
    {
        btn_GenerateStackBox.onClick.AddListener(OnClickGenerateStackBox);
        btn_DestroyStackBox.onClick.AddListener(OnClickDestroyStackBox);
    }
    #endregion

    #region private methods

    #endregion

    void RefreshStackIndexes()
    {
        for(int i = 0; i < stackBoxes.GetTotalCount(); i++) 
        {
            var element = stackBoxes.GetElementAt(i);
            element.SetIndex(i);
        }
    }



    #region callBack

    void OnClickGenerateStackBox()
    {
        var clone = Resources.Load<StackBox>("StackPractice/StackBox");
        if (clone == null)
            return;

        var stackBox = Instantiate(clone, trans_StackBoxPivot);
        if (stackBox == null)
            return;


        stackBox.SetIndex(stackBoxes.GetTotalCount());
        stackBoxes.Push(stackBox);

    }

    void OnClickDestroyStackBox()
    {
        var stackBox = stackBoxes.Pop();
        if(stackBox != null)
        {
            Destroy(stackBox.gameObject);
        }
    }

    #endregion
}
