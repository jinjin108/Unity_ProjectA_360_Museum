using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class EndingScene : MonoBehaviour
{

    private void Start()
    {
        AudioManager.instance.bgAudioSource.clip = AudioManager.instance.bgList[0];
        AudioManager.instance.bgAudioSource.Play();
    }

    public void SkipCredit()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Menu);
    }
}
