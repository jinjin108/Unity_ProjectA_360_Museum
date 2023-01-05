using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region instance

    private static ObjectManager instance = null;

    public static ObjectManager GetInstance()
    {
        if(instance == null)
        {
            GameObject go = new GameObject("@ObjectManager");
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    Dictionary<string, GameObject> objectList = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> RelicsList = new Dictionary<string, GameObject>();

    public void CreateObject(string objectName)
    {
        if (objectList.ContainsKey(objectName) == false)
        {
            Object Obj = Resources.Load("Object/" + objectName);
            GameObject go = (GameObject)Instantiate(Obj);

            objectList.Add(objectName, go);
        }
        else
        objectList[objectName].SetActive(true);
    }

    public void MoveShowcase(string objectName, Vector3 positon)
    {
        objectList[objectName].transform.position += positon;
    }

    public void InPutRelics(string relicsName,string objectName)
    {
        if (RelicsList.ContainsKey(relicsName) == false)
        {
            Object Obj = Resources.Load("Object/" + relicsName);
            GameObject go = (GameObject)Instantiate(Obj);
            
            go.transform.position = objectList[objectName].gameObject.transform.position;

            QuestObject questObject = go.GetComponent<QuestObject>();
            if (questObject.isDone == false)
            {
                go.SetActive(false);
            }

            RelicsList.Add(relicsName, go);
        }
        else
        RelicsList[relicsName].SetActive(true);
    }
}
