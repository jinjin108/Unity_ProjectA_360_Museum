using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuizScene : MonoBehaviour
{
    public Image quizImage;

    private void Start() {
        quizImage = GetComponentInChildren<Image>();
    }
}
