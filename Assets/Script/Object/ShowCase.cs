using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCase : MonoBehaviour
{
    public void EnterQuizScene()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Quiz);
    }
}
