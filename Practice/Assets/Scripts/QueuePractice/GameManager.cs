using UnityEngine;
using UnityEngine.UI;
using YYY;

public class GameManager : MonoBehaviour
{
    #region inspector
    [SerializeField] Button btn_GenerateQueueBox;
    [SerializeField] Button btn_DestroyQueueBox;
    [SerializeField] Transform trans_QueueBoxPivot;
    #endregion


    #region variables
    CustomQueue<QueueBox> queueBoxes = new CustomQueue<QueueBox>();
    #endregion



    #region overriden Methods
    void Start()
    {
        btn_GenerateQueueBox.onClick.AddListener(OnClickGenerateQueueBox);
        btn_DestroyQueueBox.onClick.AddListener(OnClickDestroyQueueBox);
    }
    #endregion

    #region private methods

    #endregion

    void RefreshQueueIndexes()
    {
        for(int i = 0; i < queueBoxes.GetTotalCount(); i++) 
        {
            var element = queueBoxes.GetElementAt(i);
            element.SetIndex(i);
        }
    }



    #region callBack

    void OnClickGenerateQueueBox()
    {
        var clone = Resources.Load<QueueBox>("QueueBox");
        if (clone == null)
            return;

        var queueBox = Instantiate(clone, trans_QueueBoxPivot);
        if (queueBox == null)
            return;


        queueBox.SetIndex(queueBoxes.GetTotalCount());
        queueBoxes.EnQueue(queueBox);

    }

    void OnClickDestroyQueueBox()
    {
        var queueBox = queueBoxes.DeQueue();
        if(queueBox != null)
        {
            Destroy(queueBox.gameObject);
        }

        //RefreshQueueIndexes();
    }

    #endregion
}
