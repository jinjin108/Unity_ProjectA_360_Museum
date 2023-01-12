using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class EndingScene : MonoBehaviour
{

    private void Start()
    {
        AudioManager.instance.audioSource.clip = AudioManager.instance.bgList[0];
        AudioManager.instance.audioSource.Play();
    }

    public void SkipCredit()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Menu);
    }
}
