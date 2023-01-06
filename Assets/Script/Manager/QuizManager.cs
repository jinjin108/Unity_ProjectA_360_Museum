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
        if(instance == null)
        {
            GameObject go = new GameObject("@QuizManager");
            instance = go.AddComponent<QuizManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    string[] quizVideoList = {"Relics_1", "Relics_2", "Relics_3"};

    public int curQuizNumber;
    string curReliceName;

    Vector3 quizojpoint;

    VideoPlayer quizVideo;
    Object spriteobj;
    public GameObject sprite;

    public void CurrentQuizStart()
    {
        GameObject quizVideogo = GameObject.FindGameObjectWithTag("VideoPlayer");
        quizVideo = quizVideogo.GetComponent<VideoPlayer>();

        quizVideo.clip = Resources.Load<VideoClip>($"Videos/"+quizVideoList[curQuizNumber]);

        switch (curQuizNumber)
        {
            case 0:
                spriteobj = Resources.Load($"Images/"+quizVideoList[curQuizNumber]);
                sprite = (GameObject)Instantiate(spriteobj);
                sprite.transform.localEulerAngles = new Vector3(0, -90f, 0);
                sprite.transform.position = new Vector3(-10.93f, 2.49f, -1.36f);
                quizojpoint = new Vector3(-10.93f, 2.49f, -1.36f);
                CreateQuizOj();

                break;
            case 1:
                spriteobj = Resources.Load($"Images/" + quizVideoList[curQuizNumber]);
                sprite = (GameObject)Instantiate(spriteobj);
                sprite.transform.localEulerAngles = new Vector3(31.77f, -81.04f, 0f);
                sprite.transform.position = new Vector3(-8.99f, 0.5f, 1.49f);
                CreateQuizOj();

                break;
            case 2:
                spriteobj = Resources.Load($"Images/" + quizVideoList[curQuizNumber]);
                sprite = (GameObject)Instantiate(spriteobj);
                sprite.transform.localEulerAngles = new Vector3(0, -90f, 0.82f);
                sprite.transform.position = new Vector3(-4.82f, 1.6f, 0.12f);
                CreateQuizOj();

                break;
        }
    }
    public GameObject CreateQuizOj()
    {
        Object createQuizOj = Resources.Load("Object/QuizOj");
        GameObject quizOj = (GameObject)Instantiate(createQuizOj);
        quizOj.transform.position = quizojpoint;

        return quizOj;
    }

}
