using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

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

    VideoPlayer quizVideo;

    public void CurrentQuizStart()
    {
        GameObject quizVideogo = GameObject.FindGameObjectWithTag("VideoPlayer");
        quizVideo = quizVideogo.GetComponent<VideoPlayer>();

        quizVideo.clip = Resources.Load<VideoClip>($"Videos/"+quizVideoList[curQuizNumber]);
    }
}
