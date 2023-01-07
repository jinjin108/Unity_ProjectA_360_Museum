using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

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

    string[] quizVideoList = { "Relics_1", "Relics_2", "Relics_3" };

    public int curQuizNumber;
    string curReliceName;

    Vector3 quizojpoint;

    VideoPlayer quizVideo;
    Object spriteobj;
    public GameObject sprite;
    public GameObject secondSprite;
    public string targetName;

    public test ReadingGlasses = new test();



    public void CurrentQuizStart()
    {
        GameObject quizVideogo = GameObject.FindGameObjectWithTag("VideoPlayer");
        quizVideo = quizVideogo.GetComponent<VideoPlayer>();

        quizVideo.clip = Resources.Load<VideoClip>($"Videos/" + quizVideoList[curQuizNumber]);

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
        spriteobj = Resources.Load($"Images/" + quizVideoList[curQuizNumber]);
        sprite = (GameObject)Instantiate(spriteobj);

        return sprite;
    }

    public GameObject CreateSecondSprite()
    {
        spriteobj = Resources.Load($"Images/" + quizVideoList[curQuizNumber]);
        secondSprite = (GameObject)Instantiate(spriteobj);

        SpriteRenderer renderer = secondSprite.GetComponent<SpriteRenderer>();
        renderer.color = new Color(1,1,1,0);
        secondSprite.transform.position = sprite.transform.position;
        secondSprite.transform.localEulerAngles = sprite.transform.localEulerAngles;

        return secondSprite;
    }
    
    public GameObject CreateTarget(string target)
    {
        Object targetObj = Resources.Load("Object/" + target);
        GameObject tar = (GameObject)Instantiate(targetObj);

        ReadingGlasses.target = tar;

        return tar;
    }

    public IEnumerator NextQuiz()
    {
        yield return new WaitForSeconds(2f);

        ReadingGlasses.gameObject.SetActive(false);

        CreateSecondSprite();

        SpriteRenderer renderer = secondSprite.GetComponent<SpriteRenderer>();

        float i = 0f;

        while (i < 1)
            {
                i += 0.1f;
                Debug.Log(i);
                Color c = renderer.color;
                c.a = i;
                renderer.color = c;
                yield return new WaitForSeconds(0.02f);
            }

    }

}


