using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEndingScene : MonoBehaviour
{
    Text rollCredit;
    Transform camera;

    private void Start()
    {
        rollCredit = gameObject.GetComponentInChildren<Text>();
        GameObject go = GameObject.FindGameObjectWithTag("XROrigin");
        camera = go.transform;
    }

    private void Update()
    {
        RollCreditStart();
    }

    void RollCreditStart()
    {
        if (camera.transform.position.z > 85f)
        {
            transform.position += new Vector3(0, 0.01f, 0);
        }
    }
}
