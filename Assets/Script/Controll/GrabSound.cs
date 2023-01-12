using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSound : MonoBehaviour
{
    public void PlayGrabSound()
    {
        AudioManager.instance.sfxAudioSource.clip = AudioManager.instance.sfxList[1];
        AudioManager.instance.sfxAudioSource.volume = 0.5f;
        AudioManager.instance.sfxAudioSource.Play();
    }
}
