using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizScene : MonoBehaviour
{
    private void Start() {
        AudioManager.GetInstance();
        QuizManager.GetInstance().CurrentQuizStart();
    }
}
