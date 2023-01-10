using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class EndingScene : MonoBehaviour
{
    //[SerializeField]
    //UIEndingScene uIEndingScene;

    private void Start()
    {
        //UIManager.GetInstance().OpenUI("UIEnding");
        //UIManager.GetInstance().SetEventSystem();
        //uIEndingScene = UIManager.GetInstance().GetUI("UIEnding").GetComponent<UIEndingScene>();
        //uIEndingScene.btnSkipCredit.onClick.AddListener(SkipCredit);
    }

    public void SkipCredit()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Menu);
    }
}
