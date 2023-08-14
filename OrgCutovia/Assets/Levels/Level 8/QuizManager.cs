using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuesrtion;
    public GameObject quizPanel;
    public GameObject gameOverPanel;

    public Text questionTxt;

    private void Start()
    {
        generateQuestion();    
    }
    public void GameOver()
    {
        StartCoroutine(GameOverScene());
       

    }
    IEnumerator GameOverScene()
    {
        TopGameManager.Instance.wipe.gameObject.SetActive(true);
        yield return null;
        TopGameManager.Instance.wipe.AnimatorIn();
        quizPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        TopGameManager.Instance.wipe.AnimatorOut();
        TopGameManager.Instance.TransOff();
        SceneManager.UnloadSceneAsync("Level8");
        /*TopGameManager.Instance.wipe.gameObject.SetActive(false);*/
        TopGameManager.Instance.button.SetActive(true); //Enabling button

    }

    public void Correct()
    {
       StartCoroutine(CorrectFunction());
    }
    IEnumerator CorrectFunction()
    {
        yield return new WaitForSeconds(1);
        QnA.RemoveAt(currentQuesrtion);
        generateQuestion();
    }
    public void Wrong()
    {
        
    }
    void SetAnswers()
    {
        for(int i=0;i<options.Length;i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].GetComponent<AnswerScript>().correctLight.SetActive(false);
            options[i].GetComponent<AnswerScript>().wrongLight.SetActive(false);
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuesrtion].answer[i];


            if (QnA[currentQuesrtion].correctAnswer==i+1)
            {
                options[i].GetComponent <AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count>0)
        {
        currentQuesrtion=Random.Range(0, QnA.Count);
        questionTxt.text = QnA[currentQuesrtion].question;
        SetAnswers();
        }
        else
        {
            GameOver();
        }

        
    }
}
