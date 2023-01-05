using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizScene : MonoBehaviour
{
    private void Start() {
        UIManager.GetInstance().OpenUI("quizImage");
        UIManager.GetInstance().SetEventSystem();
        QuizManager.GetInstance().CurrentQuizStart();
    }
}
