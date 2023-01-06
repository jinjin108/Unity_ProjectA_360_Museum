using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject target;

    private void Awake()
    {
        target = QuizManager.GetInstance().CreateTarget(QuizManager.GetInstance().targetName);

    }
    void Update()
    {

        OderVec3();

        if (Vector3.Distance(OderVec3(), OderVec4()) < 5f)
        {

        }
        Debug.Log(Vector3.Distance(OderVec3(), OderVec4()));

    }

    public Vector3 OderVec3()
    {
        Vector3 a = target.transform.localEulerAngles;
        a.z = 0;

        return a;
    }

    public Vector3 OderVec4()
    {
        Vector3 a = transform.localEulerAngles;
        a.z = 0;

        return a;
    }

}
