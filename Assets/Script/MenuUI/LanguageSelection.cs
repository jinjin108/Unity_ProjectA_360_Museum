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
    int infoscore = 0;
    int gametextstory = 0;

    [SerializeField] private PostProcessVolume ppv;

    [SerializeField] private GameObject test;

    [SerializeField] private TMP_Text txtinfo;
    [SerializeField] private TMP_Text txtinfoText;
    [SerializeField] private Button LocalizationKoBnt;
    [SerializeField] private Button LocalizationEnBnt;
    [SerializeField] private Button StartBnt;
    [SerializeField] private Button NextBnt;
    [SerializeField] private Button BackBnt;
    [SerializeField] private Material backGround;
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

        RenderSettings.skybox = backGround;
        ppv.profile.TryGetSettings(out bl);

    }
    public void UserLocalizationko()
    {
        CheckLanguages.GetInstance().selectionLanguages(1);
        txtinfoText.gameObject.SetActive(true);
        NextBnt.gameObject.SetActive(true);

        LocalizationBntFalse();
        LocalizationTable("GameInfo");
        txtinfoText.text = str;
        test.SetActive(true);

        MenuAni.GetInstance().StartWalk();
    }

    public void UserLocalizationen()
    {
        CheckLanguages.GetInstance().selectionLanguages(0);
        NextBnt.gameObject.SetActive(true);
        BackBnt.gameObject.SetActive(true);

        LocalizationBntFalse();
        LocalizationTable("GameInfo");
        txtinfoText.text = str;

        test.SetActive(true);

        MenuAni.GetInstance().StartWalk();

    }

    public void GameStart()
    {
        LocalizationKoBnt.gameObject.SetActive(true);
        LocalizationEnBnt.gameObject.SetActive(true);
        StartBnt.gameObject.SetActive(false);
        txtinfoText.gameObject.SetActive(true);
        LocalizationTable("LanguageSelection");
        txtinfoText.text = str;




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
        switch (infoscore)
        {
            case 0:
                LocalizationTable("gamestory0");
                txtinfoText.text = str;
                infoscore += 1;
                break;
            case 1:
                LocalizationTable("gamestory1");
                txtinfoText.text = str;
                infoscore += 1;
                break;
            case 2:
                LocalizationTable("gamestory2");
                txtinfoText.text = str;
                infoscore += 1;
                break;
            case 3:
                txtinfo.gameObject.SetActive(true);
                txtinfo.text = "게임 설명";
                LocalizationTable("info0");
                txtinfoText.text = str;
                infoscore += 1;
                BackBnt.gameObject.SetActive(true);
                break;
            case 4:
                LocalizationTable("info1");
                txtinfoText.text = str;
                infoscore += 1;
                break;
            case 5:
                LocalizationTable("info2");
                txtinfoText.text = str;
                infoscore += 1;
                break;
            case 6:
                LocalizationTable("info3");
                txtinfoText.text = str;
                infoscore += 1;
                break;
            case 7:
                LocalizationTable("info4");
                txtinfoText.text = str;
                infoscore += 1;
                break;
            case 8:
                LocalizationTable("info5");
                txtinfoText.text = str;
                infoscore += 1;
                break;
            case 9:
                txtinfo.gameObject.SetActive(false);
                NextBnt.gameObject.SetActive(false);
                BackBnt.gameObject.SetActive(false);
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
        switch (infoscore)
        {
            case 4:
                LocalizationTable("info1");
                txtinfoText.text = str;
                infoscore -= 1;
                break;
            case 5:
                LocalizationTable("info2");
                txtinfoText.text = str;
                infoscore -= 1;
                break;
            case 6:
                LocalizationTable("info3");
                txtinfoText.text = str;
                infoscore -= 1;
                break;
            case 7:
                LocalizationTable("info4");
                txtinfoText.text = str;
                infoscore -= 1;
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
