using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public GameObject correctLight;
    public GameObject wrongLight;
    public QuizManager quizManager;
   public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct answer");
            correctLight.SetActive(true);
            quizManager.Correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            wrongLight.SetActive(true);
            quizManager.Wrong();
        }
    }
}
