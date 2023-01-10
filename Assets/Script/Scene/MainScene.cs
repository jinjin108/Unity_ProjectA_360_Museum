using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class MainScene : MonoBehaviour
{
    [SerializeField] private PostProcessVolume ppv;
    Bloom bl;

    private void Start()
    {
        ppv.profile.TryGetSettings(out bl);
        bl.intensity.value = 100f;

        ObjectManager.GetInstance().CreateQuest();
        ObjectManager.GetInstance().MoveShowcase(0, new Vector3(-5f, 0, 0));
        ObjectManager.GetInstance().MoveShowcase(2, new Vector3(5f, 0, 0));
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
