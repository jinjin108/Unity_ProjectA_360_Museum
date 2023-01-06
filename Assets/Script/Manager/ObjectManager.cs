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

    public Dictionary<string, GameObject> objectList = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> RelicsList = new Dictionary<string, GameObject>();
    List<GameObject> SymbolList = new List<GameObject>();

    public void CreateQuest()
    {
        QuestObject[] questObjectList = QuestManager.GetInstance().questObjectList;

        for (int i = 0; i < questObjectList.Length; i++)
        {
            string showCaseName = questObjectList[i].showCaseName;
            string reliceName = questObjectList[i].reliceName;

            CreateObject(showCaseName);
            InPutRelics(reliceName, showCaseName);
            CreateSymbol(reliceName);
        }
    }
    //public GameObject CreateQuizOj(string quizojName)
    //{
    //    Object createQuizOj = Resources.Load("Resources/" + quizojName);
    //    GameObject quizOj = (GameObject)Instantiate(createQuizOj);

    //    return quizOj;
    //}


    public void CreateObject(string objectName)
    {
        if (objectList.ContainsKey(objectName) == false)
        {
            Object Obj = Resources.Load("Object/" + objectName);
            GameObject go = (GameObject)Instantiate(Obj);
            
            int index = go.name.IndexOf("(Clone)");
            if (index > 0) 
            go.name = go.name.Substring(0, index);

            objectList.Add(objectName, go);
        }
        else
        objectList[objectName].SetActive(true);
    }

    public void MoveShowcase(int questNumber ,Vector3 positon)
    {
        QuestObject[] questObjectList = QuestManager.GetInstance().questObjectList;
        string showCaseName = questObjectList[questNumber].showCaseName;
        string reliceName = questObjectList[questNumber].reliceName;

        objectList[showCaseName].transform.position += positon;
        RelicsList[reliceName].transform.position += positon;
        SymbolList[questNumber].transform.position += positon;
    }

    public void InPutRelics(string relicsName,string objectName)
    {
        if (RelicsList.ContainsKey(relicsName) == false)
        {
            Object Obj = Resources.Load("Object/" + relicsName);
            GameObject go = (GameObject)Instantiate(Obj);

            go.transform.position = objectList[objectName].gameObject.transform.position;
            go.transform.position = new Vector3(0,1f,0);

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

    public void CreateSymbol(string reliceName)
    {
        Object Obj = Resources.Load("Object/" + "Symbol");
        GameObject go = (GameObject)Instantiate(Obj);
        go.transform.position = RelicsList[reliceName].gameObject.transform.position;
        go.transform.position += new Vector3(0,1.5f,0); 

        SymbolList.Add(go);

        if (RelicsList[reliceName].gameObject.activeSelf == true)
        {
            go.SetActive(false);
        }
    }

    public GameObject GetObject(string objectName)
    {
        if (objectList.ContainsKey(objectName))
            return objectList[objectName];

        return null;

    }

    public void ClearList() 
    {                       
        objectList.Clear();
        RelicsList.Clear();
        SymbolList.Clear();
    }
}
