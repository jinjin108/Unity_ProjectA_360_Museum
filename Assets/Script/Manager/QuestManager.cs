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

    public Sumacsae[] sumacsaesList = {
        new Sumacsae("Sumacsae_1"),
        new Sumacsae("Sumacsae_2"),
        new Sumacsae("Sumacsae_3"),
    };

    public void ClearGame()
    {

        for (int i = 0; i < sumacsaesList.Length; i++)
        {
            if (sumacsaesList[i].isClear == false)
            {
                return;
            }
        }

        Invoke("CreatePotar", 3f);
        Debug.Log("Open The Door");

    }

    public void CreatePotar()
    {
        ObjectManager.GetInstance().CreateEndingPotar();
    }
}
