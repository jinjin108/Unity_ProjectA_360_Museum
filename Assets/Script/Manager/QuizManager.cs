using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;
using UnityEngine.ResourceManagement.AsyncOperations;



public class QuizManager : MonoBehaviour
{
    #region instance

    private static QuizManager instance = null;

    public static QuizManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@QuizManager");
            instance = go.AddComponent<QuizManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public int infiPageNumber;
    public int curQuizNumber;
    string curReliceName;
    string info;

    Vector3 quizojpoint;
    Vector3 checkPosition;
    public Transform secondGameCamera;
    private Vector3 destination;
    public XRRayInteractor Interactor;
    bool isSecondGame;
    bool isMove;

    VideoPlayer quizVideo;
    Object spriteobj;
    public GameObject sprite;
    GameObject secondGame;
    public GameObject relics = null;
    public string targetName;
    public Transform secondGameObject;

    public test ReadingGlasses = new test();
    public Image fadeIn;
    public PostProcessVolume ppv;
    AutoExposure ae;
    ColorGrading cg;
    MeshRenderer[] secondGameCube_1;
    public Image relicsInfo;
    public TMP_Text relicsInfotxt;

    private void Update()
    {

        CheckSecondAnswerPosition();

        CheckInputFromeXR();

        Move();

    }


    public void CurrentQuizStart()
    {
        GameObject quizVideogo = GameObject.FindGameObjectWithTag("VideoPlayer");
        quizVideo = quizVideogo.GetComponent<VideoPlayer>();

        quizVideo.clip = Resources.Load<VideoClip>($"Videos/" + QuestManager.GetInstance().questObjectList[curQuizNumber].reliceName);

        switch (curQuizNumber)
        {
            case 0:
                CreateSprite();
                sprite.transform.localEulerAngles = new Vector3(0, -90f, 0);
                sprite.transform.position = new Vector3(-10.93f, 2.49f, -1.36f);
                quizojpoint = new Vector3(-10.93f, 2.49f, -1.36f);
                targetName = "target_1";
                CreateTarget(targetName);
                break;
            case 1:
                CreateSprite();
                sprite.transform.localEulerAngles = new Vector3(31.77f, -81.04f, 0f);
                sprite.transform.position = new Vector3(-8.99f, 0.5f, 1.49f);
                targetName = "target_2";
                CreateTarget(targetName);
                break;
            case 2:
                CreateSprite();
                sprite.transform.localEulerAngles = new Vector3(0, -90f, 0.82f);
                sprite.transform.position = new Vector3(-4.82f, 1.6f, 0.12f);
                targetName = "target_3";
                CreateTarget(targetName);
                break;
        }
    }

    public GameObject CreateSprite()
    {
        spriteobj = Resources.Load($"Images/" + QuestManager.GetInstance().questObjectList[curQuizNumber].reliceName);
        sprite = (GameObject)Instantiate(spriteobj);

        return sprite;
    }

    public GameObject CreateSecondGame()
    {
        GameObject postv = GameObject.FindGameObjectWithTag("Post");
        ppv = postv.GetComponent<PostProcessVolume>();
        ppv.profile.TryGetSettings(out ae);
        ppv.profile.TryGetSettings(out cg);

        GameObject fadeinimg = GameObject.FindGameObjectWithTag("Img");
        fadeIn = fadeinimg.GetComponent<Image>();

        StartCoroutine("SkyFadeIn");

        Object obj = Resources.Load($"Object/" + "SecondGame");
        secondGame = (GameObject)Instantiate(obj);
        secondGameCube_1 = secondGame.GetComponentsInChildren<MeshRenderer>();

        StartCoroutine("FadeSystem");
        Invoke("SkyBoxChange", 5f);
        MeshRenderer secondGameCube = secondGame.GetComponentInChildren<MeshRenderer>();
        Material mat = secondGameCube.material;

        switch (curQuizNumber)
        {
            case 0:
                Texture tex_1 = Resources.Load("Images/CulturalHeritage_1", typeof(Texture)) as Texture;
                mat.SetTexture("_MainTex", tex_1);
                secondGame.transform.position = new Vector3(-13.48f, 2.16f, -6.23f);
                break;
            case 1:
                secondGameCube_1[0].transform.localScale = new Vector3(0.05f, 7.6f, 9f);
                secondGameCube_1[0].transform.position = new Vector3(-10.8f, -1.3f, 0.3f);
                secondGameCube_1[1].transform.localScale = new Vector3(0.02f, 3.3f, 4f);
                secondGameCube_1[1].transform.position = new Vector3(-10.4f, 0.6f, 7.3f);
                secondGameCube_1[1].transform.rotation = new Quaternion(0, -173.3f,0,0);

                Texture tex_2 = Resources.Load("Images/CulturalHeritage_3", typeof(Texture)) as Texture;
                mat.SetTexture("_MainTex", tex_2);
                break;
            case 2:
                secondGameCube_1[0].transform.localScale = new Vector3(0.05f, 13.42f, 21.4f);
                secondGameCube_1[0].transform.position = new Vector3(-11f, 5f, -0.7f);
                secondGameCube_1[1].transform.localScale = new Vector3(0.02f, 4.9f, 5.5f);
                secondGameCube_1[1].transform.position = new Vector3(-11f, 8.5f, 12.8f);

                Texture tex_3 = Resources.Load("Images/CulturalHeritage_2", typeof(Texture)) as Texture;
                mat.SetTexture("_MainTex", tex_3);
                break;
        }

        secondGameCamera = secondGame.GetComponentInChildren<Camera>().transform;
        CreateSecondGameObject();

        return secondGame;
    }

    public GameObject CreateTarget(string target)
    {
        Object targetObj = Resources.Load("Object/" + target);
        GameObject tar = (GameObject)Instantiate(targetObj);

        ReadingGlasses.target = tar;

        return tar;
    }

    public void CreateSecondGameObject()
    {
        MeshRenderer secondGameObjectms = secondGame.GetComponentInChildren<MeshRenderer>();
        secondGameObject = secondGameObjectms.transform;

        Vector3 curPos = secondGameObject.position;

        //float randX = curPos.x;

        float randY = Random.Range(-(secondGameObject.lossyScale.y / 2), (secondGameObject.lossyScale.y / 2));
        float randZ = Random.Range(-(secondGameObject.lossyScale.z / 2), (secondGameObject.lossyScale.z / 2));
        curPos.x += 0.5f;
        curPos.y += randY;
        curPos.z += randZ;

        //Vector3 ran = new Vector3(randX, randY, randZ);
            
        Object relicsObj = Resources.Load($"Object/Relics_1{curQuizNumber}");
        relics = (GameObject)Instantiate(relicsObj, curPos, Quaternion.identity);
    }

    public IEnumerator NextQuiz()
    {
        yield return new WaitForSeconds(2f);

        ReadingGlasses.gameObject.SetActive(false);
        sprite.SetActive(false);

        CreateSecondGame();

        isSecondGame = true;




        // float i = 0f;

        // while (i < 1)
        //     {
        //         i += 0.1f;
        //         Debug.Log(i);
        //         Color c = renderer.color;
        //         c.a = i;
        //         renderer.color = c;
        //         yield return new WaitForSeconds(0.02f);
        //     }

    }

    public void CheckInputFromeXR()
    {
        if (GameObject.FindGameObjectWithTag("XROrigin") != null)
        {
            GameObject Interactorgo = GameObject.FindGameObjectWithTag("XROrigin");
            Interactor = Interactorgo.GetComponentInChildren<XRRayInteractor>();
        }

        if (isSecondGame == false)
        {
            return;
        }

        if (Interactor == null)
        {
            return;
        }

        RaycastHit hit;
        if (Interactor.TryGetCurrent3DRaycastHit(out hit))
        {
            SetDestination(hit.point);
        }
    }

    private void SetDestination(Vector3 dest)
    {
        destination = dest;
        destination.x = -9f;
        isMove = true;
    }

    private void Move()
    {
        if (isMove)
        {
            if (Vector3.Distance(destination, transform.position) <= 0.1f)
            {
                isMove = false;
                return;
            }

            //var dir = destination - transform.position;
            //chracter.transform.forward = -dir;
            if (secondGameCamera != null)
            {
                secondGameCamera.transform.position = destination;
            }

        }
    }

    public void CheckSecondAnswerPosition()
    {
        if (relics == null)
        {
            return;
        }
        checkPosition = secondGameCamera.transform.position;
        checkPosition.x = relics.transform.position.x;

        if (Vector3.Distance(checkPosition, relics.transform.position) < 0.2f)
        {
            QuestManager.GetInstance().questObjectList[curQuizNumber].isDone = true;
            QuestManager.GetInstance().sumacsaesList[curQuizNumber].isClear = true;
            relics = null;
            StartCoroutine("FostFadeSystem");

        }
    }
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(2.5f);

        while (fadeIn.color.a >= 0)
        {

            float alpha = fadeIn.color.a + 0.0035f;
            fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, alpha);
            yield return null;
        }

    }

    IEnumerator Fadeout()
    {

        while (fadeIn.color.a >= 0)
        {

            float alpha = fadeIn.color.a - 0.0035f;
            fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, alpha);
            yield return null;
        }

    }
    IEnumerator FadeSystem()
    {
        StartCoroutine("FadeIn");
        yield return new WaitForSeconds(4.5f);
        StopCoroutine("FadeIn");
        StartCoroutine("Fadeout");
        StartCoroutine("SkyFadeOut");
        yield return new WaitForSeconds(2f);
        StopCoroutine("Fadeout");
    }

    public void SkyBoxChange()
    {
        quizVideo.clip = Resources.Load<VideoClip>($"Videos/Relics_4");
    }

    IEnumerator FostFadeSystem()
    {
        StartCoroutine("FostFadeIn");
        yield return new WaitForSeconds(1.5f);
        StopCoroutine("FostFadeIn");
        StartCoroutine("FostFadeout");
        yield return new WaitForSeconds(1.5f);
        StopCoroutine("FostFadeout");
        RelicsInfo();
        //ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

    IEnumerator FostFadeIn()
    {
        while (ae.minLuminance.value > -9f)
        {
            ae.minLuminance.value -= 0.2f;

            yield return new WaitForSeconds(0.09f);
        }

    }
    IEnumerator FostFadeout()
    {
        while (ae.minLuminance.value < 0f)
        {
            ae.minLuminance.value += 0.15f;

            yield return new WaitForSeconds(0.05f);

        }
    }
    IEnumerator SkyFadeIn()
    {

        while (cg.saturation.value > -100f)
        {
            cg.saturation.value -= 1f;

            yield return new WaitForSeconds(0.025f);
        }
    }
    IEnumerator SkyFadeOut()
    {

        while (cg.saturation.value < 100f)
        {
            cg.saturation.value += 1f;

            yield return new WaitForSeconds(0.0001f);
        }
    }

    public void LocalizationTable(string key)
    {
        var stringOperation = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("New Table", key);
        if (stringOperation.IsDone && stringOperation.Status == AsyncOperationStatus.Succeeded)
        {
            info = stringOperation.Result;
        }
    }
    void RelicsInfo()
    {
        Object InfoObj = Resources.Load("Object/ExplanationOfRelics");
        GameObject tar = (GameObject)Instantiate(InfoObj);
        tar.transform.position = sprite.transform.position;
        tar.transform.localEulerAngles = sprite.transform.localEulerAngles;
        GameObject InfoImg = GameObject.FindGameObjectWithTag("RelicsInfo");
        relicsInfo = InfoImg.GetComponent<Image>();
        GameObject Infotxt = GameObject.FindGameObjectWithTag("RelicsInfoText");
        relicsInfotxt = Infotxt.GetComponent<TMP_Text>();
        LocalizationTable($"Relics_Info_{curQuizNumber}_{a}");
        relicsInfotxt.text = info;
    }
    public void InfoNext()
    {

    }
}


