using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGame : MonoBehaviour
{
    public Camera scondGameCamera;
    public MeshRenderer go;
    private void Start()
    {
        scondGameCamera = GetComponentInChildren<Camera>();
        go = GetComponentInChildren<MeshRenderer>();
    }
}
