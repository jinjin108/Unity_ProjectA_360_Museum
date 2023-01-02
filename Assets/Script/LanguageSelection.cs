using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageSelection : MonoBehaviour
{
    void Start()
    {
      //  UserLocalization(1);
    }

    void Update()
    {
        
    }
    public void UserLocalization(int index)
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[index];
    }

}
