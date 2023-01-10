using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEndingScene : MonoBehaviour
{
    public Button btnSkipCredit;

    private void Awake()
    {
        btnSkipCredit = gameObject.GetComponentInChildren<Button>();
    }
}
