using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    private void Start() {
        ObjectManager.GetInstance().CreateObject("ShowCase1");
        ObjectManager.GetInstance().MoveShowcase("ShowCase1", new Vector3(-5, 0, 0));
        ObjectManager.GetInstance().InPutRelics("QuestObject", "ShowCase1");
    }
}
