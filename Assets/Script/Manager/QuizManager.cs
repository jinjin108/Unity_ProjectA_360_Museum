using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    #region instance

    private static QuizManager instance = null;

    public static QuizManager GetInstance()
    {
        if(instance == null)
        {
            GameObject go = new GameObject("@QuizManager");
            instance = go.AddComponent<QuizManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public int curQuizNumber;
}
