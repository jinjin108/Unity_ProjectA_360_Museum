using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.bgAudioSource.clip = AudioManager.instance.bgList[0];
        AudioManager.instance.bgAudioSource.Play();
    }
}
