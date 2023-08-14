using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ShapeAnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public GameObject answerLight;
    public ShapeQuizManager quizManager;
    public Text particleText;
    public ParticleSystem message;
    public void Answer()
    {
        answerLight.SetActive(true);
        if(isCorrect)
        {
            /*Debug.Log("The answer is also correct");*/
            particleText.text = "Hurray!!!";
            message.Play();
            quizManager.Correct();
        }
        else
        {
            /*Debug.Log("Wrong Answer");*/
            particleText.text = "Oops, that's not the right Object. Try again.";
            message.Play();
            quizManager.Wrong();
        }

    }
}
