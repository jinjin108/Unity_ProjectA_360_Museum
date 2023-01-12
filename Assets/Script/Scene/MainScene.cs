using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class MainScene : MonoBehaviour
{
    [SerializeField] private PostProcessVolume ppv;
    public Bloom bl;
    public AutoExposure ae;

    private void Start()
    {

        AudioManager.instance.bgAudioSource.clip = AudioManager.instance.bgList[0];
        AudioManager.instance.bgAudioSource.Play();
        AudioManager.instance.bgAudioSource.volume = 0.3f;

        QuizManager.GetInstance().infiPageNumber = 0;
        ppv.profile.TryGetSettings(out bl);
        ppv.profile.TryGetSettings(out ae);
        bl.intensity.value = 100f;

        ObjectManager.GetInstance().CreateQuest();
        ObjectManager.GetInstance().MoveShowcase(0, new Vector3(12.5f, 3.5f, -3f));
        ObjectManager.GetInstance().MoveShowcase(2, new Vector3(-6f, 4f, 19f));
        ObjectManager.GetInstance().MoveSymboll(0, new Vector3(-3.5f,3.5f,0));
        ObjectManager.GetInstance().MoveSymboll(2, new Vector3(0,0.5f,0));
        ObjectManager.GetInstance().CreateSumacsae();
        ObjectManager.GetInstance().MoveSumacsae(0, new Vector3(-5f, 5f, 0));
        ObjectManager.GetInstance().MoveSumacsae(1, new Vector3(0, 5f, 0));
        ObjectManager.GetInstance().MoveSumacsae(2, new Vector3(5f, 5f, 0));

        QuestManager.GetInstance().ClearGame();

        StartCoroutine("FostFadeOut");

    }
    IEnumerator FostFadeOut()
    {
        while (bl.intensity.value > 0f)
        {
            bl.intensity.value -= 1f;

            yield return new WaitForSeconds(0.01f);
        }

    }
}
