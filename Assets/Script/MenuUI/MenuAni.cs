using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAni : MonoBehaviour
{
    #region instance

    private static MenuAni instance = null;

    public static MenuAni GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@MenuAni");
            instance = go.AddComponent<MenuAni>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public Animator ani;
    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        ani = player.GetComponent<Animator>();
        ani.SetBool("Walk", false);
        ani.SetBool("Run", false);

    }

    public void StartWalk()
    {
        ani.SetBool("Walk",true);
    }
    public void StartRun()
    {
        ani.SetBool("Run",true);
    }

}
