using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageSelection : MonoBehaviour
{
    [SerializeField] private TMP_Text txtinfo;
    private void Start()
    {
        txtinfo.gameObject.SetActive(false);

    }
    public void UserLocalization()
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[1];
        txtinfo.gameObject.SetActive(true);
    }

    public void UserLocalizationko()
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[0];
        txtinfo.gameObject.SetActive(true);

    }
}
