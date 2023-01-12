using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Rendering.PostProcessing;



public class EndingPotar : MonoBehaviour
{
    [SerializeField] private PostProcessVolume ppv;
    public Bloom bl;
    public AutoExposure ae;

    XRGrabInteractable xrG;

    void Start()
    {
        GameObject postv = GameObject.FindGameObjectWithTag("Post");
        ppv = postv.GetComponent<PostProcessVolume>();
        xrG = GetComponent<XRGrabInteractable>();
        ppv.profile.TryGetSettings(out bl);
        ppv.profile.TryGetSettings(out ae);

    }

    public void StartFostFadeIn()
    {
        StartCoroutine("FostFadeIn");
    }
    IEnumerator FostFadeIn()
    {
        while (bl.intensity.value < 100f)
        {
            bl.intensity.value += 0.5f;

            yield return new WaitForSeconds(0.01f);
        }
    }


    public void EnterEndingScene()
    {
        StartFostFadeIn();
        Invoke("ChangeEndingScene", 3f);
    }

    public void ChangeEndingScene()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Ending);

    }
}
