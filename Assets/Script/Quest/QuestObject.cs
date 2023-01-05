using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public string reliceName;
    public string showCaseName;
    public bool isDone;

    public QuestObject(string showCaseName, string reliceName)
    {
        this.showCaseName = showCaseName;
        this.reliceName = reliceName;
        isDone = false;
    }
}
