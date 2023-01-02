using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    #region instance

    private static UIManager instance = null;

    public static UIManager GetInstance()
    {
        if(instance == null)
        {
            GameObject go = new GameObject("@UIManager");
            instance = go.AddComponent<UIManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion
    
    #region UI Control

    public void SetEventSystem()
    {
       if(FindObjectOfType<EventSystem>() == null)
        {
            GameObject go = new GameObject("@EventSystem");
            go.AddComponent<EventSystem>();
            go.AddComponent<StandaloneInputModule>();
        }
    }
    Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();

    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false)
        {
            Object uiObj = Resources.Load("UI/" + uiName);
            GameObject go = (GameObject)Instantiate(uiObj);

            uiList.Add(uiName, go);
        }
        else
            uiList[uiName].SetActive(true);

    }

    /// <summary>
    /// UI�� �ݴ� �Լ��Դϴ�.
    /// </summary>
    /// <param name="uiName">�ݾƾ��ϴ� ui�� string �Դϴ�.</param>
    public void CloseUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
            uiList[uiName].SetActive(false);
    }

    public GameObject GetUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
            return uiList[uiName];

        return null;

    }

    public void ClearList() // ����ȯ�� �Ҷ� ����Ʈ�� �ҷ��°͵��� ���� �� �������� �����⸸ ���Ƽ��´� �׷��� ���� �ҷ�������
    {                       // �ִٰ� �����ؼ� ������� �����ʾ� ������ �߻��Ѵ� �׷��������ִ°�
        uiList.Clear();
    }
    #endregion

}
