using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Vector3 other;
    public Vector3 gg;

    public GameObject target;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OderVec3();

        if (Vector3.Distance(OderVec3(),OderVec4()) < 5f)
        {
            Debug.Log("실행");
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
