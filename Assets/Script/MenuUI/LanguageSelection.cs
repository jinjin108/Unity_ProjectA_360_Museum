using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LanguageSelection : MonoBehaviour
{
    string str;


    [SerializeField] private TMP_Text txtinfo;
    [SerializeField] private TMP_Text txtinfoText;
    [SerializeField] private Button LocalizationKoBnt;
    [SerializeField] private Button LocalizationEnBnt;
    [SerializeField] private Button StartBnt;

    private void Start()
    {
        txtinfo.gameObject.SetActive(false);
        txtinfoText.gameObject.SetActive(false);
        LocalizationBntFalse();


    }
    public void UserLocalizationko()
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[1];
        txtinfoText.gameObject.SetActive(true);
        LocalizationBntFalse();
        LocalizationTable();
        txtinfo.text = str;


    }

    public void UserLocalizationen()
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[0];
        txtinfoText.gameObject.SetActive(true);
        LocalizationBntFalse();

    }

    public void GameStart()
    {
        LocalizationKoBnt.gameObject.SetActive(true);
        LocalizationEnBnt.gameObject.SetActive(true);
        StartBnt.gameObject.SetActive(false);
        txtinfo.gameObject.SetActive(true);
    }

    public void LocalizationBntFalse()
    {
        LocalizationKoBnt.gameObject.SetActive(false);
        LocalizationEnBnt.gameObject.SetActive(false);

    }

    public string LocalizationTable()
    {

        var stringOperation = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("New Table", "GameInfo");
        if (stringOperation.IsDone && stringOperation.Status == AsyncOperationStatus.Succeeded)
        {
            str = stringOperation.Result;
        }

        return str;
    }
}
