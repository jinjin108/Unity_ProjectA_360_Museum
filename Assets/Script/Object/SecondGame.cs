using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGame : MonoBehaviour
{
    public Camera scondGameCamera;
    private void Start() {
        scondGameCamera = GetComponentInChildren<Camera>();
    }
}
