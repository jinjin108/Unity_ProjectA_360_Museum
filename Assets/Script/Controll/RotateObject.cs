using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    void Update()
    {
        transform.localEulerAngles += new Vector3(0,0.4f,0);
    }
}
