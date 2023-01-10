using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Rendering.PostProcessing;
public class LanguageSelection : MonoBehaviour
{
    string str;
    int txtscore = 0;

    [SerializeField] private PostProcessVolume ppv;

    [SerializeField] private GameObject test;

    [SerializeField] private TMP_Text txtinfo;
    [SerializeField] private TMP_Text txtinfoText;
    [SerializeField] private Button LocalizationKoBnt;
    [SerializeField] private Button LocalizationEnBnt;
    [SerializeField] private Button StartBnt;
    [SerializeField] private Button NextBnt;
    [SerializeField] private Button BackBnt;
    [SerializeField] private Material skybox;
    [SerializeField] private Light point;


    Bloom bl;
    private void Start()
    {
        test.SetActive(false);
        txtinfo.gameObject.SetActive(false);
        txtinfoText.gameObject.SetActive(false);
        NextBnt.gameObject.SetActive(false);
        BackBnt.gameObject.SetActive(false);
        LocalizationBntFalse();

        RenderSettings.skybox = skybox;


        ppv.profile.TryGetSettings(out bl);

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
        test.SetActive(true);

        RenderSettings.skybox = default;
        MenuAni.GetInstance().StartWalk();
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
        test.SetActive(true);

        RenderSettings.skybox = default;
        MenuAni.GetInstance().StartWalk();

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
            case 2:
                LocalizationTable("info3");
                txtinfoText.text = str;
                txtscore += 1;
                break;
            case 3:
                LocalizationTable("info3");
                txtinfoText.text = str;
                txtscore += 1;
                break;
            case 4:
                LocalizationTable("info3");
                txtinfoText.text = str;
                txtscore += 1;
                break;

            case 5:
                StartCoroutine("FostFadeIn");
                StartCoroutine("PointFadeIn");
                txtinfoText.text = "박물관으로..";
                Invoke("ChangMainScene", 3f);
                MenuAni.GetInstance().StartRun();
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
            case 3:
                LocalizationTable("info2");
                txtinfoText.text = str;
                txtscore -= 1;
                break;
            case 4:
                LocalizationTable("info2");
                txtinfoText.text = str;
                txtscore -= 1;
                break;

        }


    }

    IEnumerator FostFadeIn()
    {
        while (bl.intensity.value < 1f)
        {
            bl.intensity.value += 0.005f;

            yield return new WaitForSeconds(0.1f);
        }

    }
    IEnumerator PointFadeIn()
    {
        while (point)
        {
            point.intensity += 0.01f;

            yield return new WaitForSeconds(0.1f);
        }

    }

    
    void ChangMainScene()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

}
