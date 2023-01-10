using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

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

    public int curQuizNumber;
    string curReliceName;

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

    private void Update() {
        
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
        Object obj = Resources.Load($"Object/" + "SecondGame");
        secondGame = (GameObject)Instantiate(obj);
        MeshRenderer secondGameCube = secondGame.GetComponentInChildren<MeshRenderer>();
        Material mat = secondGameCube.material;

        switch (curQuizNumber)
        {
            case 0:
            Texture tex_1 = Resources.Load("Images/CulturalHeritage_1",typeof(Texture)) as Texture;
            mat.SetTexture("_MainTex",tex_1);
            secondGame.transform.position = new Vector3(-13.48f, 2.16f, -6.23f);
                break;
            case 1:
            Texture tex_2 = Resources.Load("Images/CulturalHeritage_3",typeof(Texture)) as Texture;
            mat.SetTexture("_MainTex",tex_2);
            break;
            case 2:
            Texture tex_3 = Resources.Load("Images/CulturalHeritage_2",typeof(Texture)) as Texture;
            mat.SetTexture("_MainTex",tex_3);
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

        float width = secondGameObject.position.x;

        float randY = Random.Range(-(secondGameObject.lossyScale.y / 2), (secondGameObject.lossyScale.y / 2));
        float randZ = Random.Range(-(secondGameObject.lossyScale.z / 2), (secondGameObject.lossyScale.z / 2));


        Vector3 ran = new Vector3(width, randY, randZ);

        Object relicsObj = Resources.Load($"Object/" + QuestManager.GetInstance().questObjectList[curQuizNumber].reliceName);
        relics = (GameObject)Instantiate(relicsObj, ran, Quaternion.identity);
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

        if (Vector3.Distance(checkPosition, relics.transform.position) < 0.1f)
            {
            QuestManager.GetInstance().questObjectList[curQuizNumber].isDone = true;
            QuestManager.GetInstance().sumacsaesList[curQuizNumber].isClear = true;
            relics = null;

            ScenesManager.GetInstance().ChangeScene(Scene.Main);
            }
    }

}


