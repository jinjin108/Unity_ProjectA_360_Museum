using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        if (Vector3.Distance(AnswerPosition(), ReadingGlassesPosition()) < 5f)
        {
            Debug.Log("실 행");
        }

    }

    public Vector3 AnswerPosition()
    {
        Vector3 a = target.transform.localEulerAngles;
        a.z = 0;

        return a;
    }

    public Vector3 ReadingGlassesPosition()
    {
        Vector3 a = transform.localEulerAngles;
        a.z = 0;

        return a;
    }

}
