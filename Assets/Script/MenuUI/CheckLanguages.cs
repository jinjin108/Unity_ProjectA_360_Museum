using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;


public class CheckLanguages : MonoBehaviour
{
    #region instance

    private static CheckLanguages instance = null;

    public static CheckLanguages GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@CheckLanguages");
            instance = go.AddComponent<CheckLanguages>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public void selectionLanguages(int a)
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[a];
    }
}
