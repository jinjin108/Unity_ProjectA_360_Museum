using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    private void Start() {
        ObjectManager.GetInstance().CreateQuest();
        ObjectManager.GetInstance().MoveShowcase(0, new Vector3(-5f,0,0));
    }
}
