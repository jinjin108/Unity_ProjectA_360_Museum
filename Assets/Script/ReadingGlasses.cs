using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadingGlasses : MonoBehaviour
{
    public GameObject target;

    private void Start() {
        QuizManager.GetInstance().ReadingGlasses = this;
    }

    void Update()
    {
        if (Vector3.Distance(AnswerPosition(), ReadingGlassesPosition()) < 5f)
        {
            StartCoroutine(QuizManager.GetInstance().NextQuiz());
        }

    }

    public Vector3 AnswerPosition()
    {
        Vector3 a = target.transform.localEulerAngles;
        a.z = 0;

        return a;
    }

    public Vector3 ReadingGlassesPosition()
    {
        Vector3 a = transform.localEulerAngles;
        a.z = 0;

        return a;
    }

}
