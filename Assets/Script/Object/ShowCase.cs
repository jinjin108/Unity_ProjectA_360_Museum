using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCase : MonoBehaviour
{

    public void EnterQuizScene()
    {
        var showCaseNameList = new List<string>(ObjectManager.GetInstance().objectList.Keys);

        for (int i = 0; i < showCaseNameList.Count; i++)
        {
            if (gameObject.name == showCaseNameList[i])
            {
                QuizManager.GetInstance().curQuizNumber = i;
            }
        }

        ScenesManager.GetInstance().ChangeScene(Scene.Quiz);
    }
}
