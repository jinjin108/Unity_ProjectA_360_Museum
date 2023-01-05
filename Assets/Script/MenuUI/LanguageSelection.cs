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
    int txtscore = 0;

    [SerializeField] private TMP_Text txtinfo;
    [SerializeField] private TMP_Text txtinfoText;
    [SerializeField] private Button LocalizationKoBnt;
    [SerializeField] private Button LocalizationEnBnt;
    [SerializeField] private Button StartBnt;
    [SerializeField] private Button NextBnt;
    [SerializeField] private Button BackBnt;



    private void Start()
    {

        GameObject.Find("gameinfoText");
        GameObject.Find("ButtonKo");
        GameObject.Find("ButtonEn");
        GameObject.Find("GameStart");
        GameObject.Find("Next");
        GameObject.Find("Back");


        txtinfo.gameObject.SetActive(false);
        txtinfoText.gameObject.SetActive(false);
        NextBnt.gameObject.SetActive(false);
        BackBnt.gameObject.SetActive(false);
        LocalizationBntFalse();


    }
    public void UserLocalizationko()
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[1];
        txtinfoText.gameObject.SetActive(true);
        NextBnt.gameObject.SetActive(true);
        BackBnt.gameObject.SetActive(true);

        LocalizationBntFalse();
        LocalizationTable("GameInfo");
        txtinfo.text = str;


    }

    public void UserLocalizationen()
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[0];
        txtinfoText.gameObject.SetActive(true);
        NextBnt.gameObject.SetActive(true);
        BackBnt.gameObject.SetActive(true);

        LocalizationBntFalse();
        LocalizationTable("GameInfo");
        txtinfo.text = str;


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

    public void LocalizationTable(string key)
    {
        var stringOperation = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("New Table", key);
        if (stringOperation.IsDone && stringOperation.Status == AsyncOperationStatus.Succeeded)
        {
            str = stringOperation.Result;
        }
    }

    public void NextText()
    {
        switch (txtscore)
        {
            case 0:
                LocalizationTable("info2");
                txtinfoText.text = str;
                txtscore += 1;
                break;
            case 1:
                LocalizationTable("info3");
                txtinfoText.text = str;
                txtscore += 1;
                break;
            case 5:
                ScenesManager.GetInstance().ChangeScene(Scene.Main);
                break;

        }

    }
    public void BackText()
    {
        switch (txtscore)
        {
            case 1:
                LocalizationTable("info1");
                txtinfoText.text = str;
                txtscore -= 1;
                break;
            case 2:
                LocalizationTable("info2");
                txtinfoText.text = str;
                txtscore -= 1;
                break;

        }

    }

}
