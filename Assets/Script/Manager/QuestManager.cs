using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    #region instance

    private static QuestManager instance = null;

    public static QuestManager GetInstance()
    {
        if(instance == null)
        {
            GameObject go = new GameObject("@QuestManager");
            instance = go.AddComponent<QuestManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public QuestObject[] questObjectList = {
        new QuestObject("ShowCase1", "Relics_1"),
        new QuestObject("ShowCase2", "Relics_2"),
        new QuestObject("ShowCase3", "Relics_3")
    };
}
