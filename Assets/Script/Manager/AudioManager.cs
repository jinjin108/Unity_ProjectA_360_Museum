using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region instance

    private static AudioManager instance = null;

    public static AudioManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@AudioManager");
            instance = go.AddComponent<AudioManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public List<AudioClip> bgList = new List<AudioClip>();
    public List<AudioClip> sfxList = new List<AudioClip>();

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
