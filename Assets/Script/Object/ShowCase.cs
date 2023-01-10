using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShowCase : MonoBehaviour
{
    public bool isDone;
    XRGrabInteractable xrG;

    private void Start()
    {
        xrG = GetComponent<XRGrabInteractable>();
    }

    private void Update()
    {
        if (isDone == true)
        {
            xrG.enabled = false;
        }
    }

    public void EnterQuizScene()
    {


        var showCaseNameList = new List<string>(ObjectManager.GetInstance().showCaseList.Keys);

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
