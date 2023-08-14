using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShapeQuizManager : MonoBehaviour
{
    public List<ShapeQuestionAndAnswer> QnA;
    public GameObject[] questionNo;
    public int currentQuesrtion=-1;
    public Text questionTxt;
    public GameObject quizPanel;
    public GameObject gameOverPanel;

    private void Start()
    {
        generateQuestion();
    }
    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuesrtion ++;
            questionNo[currentQuesrtion].SetActive(true);
            questionTxt.text = QnA[0].question;

            SetAnswers();
        }
        else
        {
            GameOver();
            Debug.Log("All questions are finished");
        }
    }
    void GameOver()
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
        SceneManager.UnloadSceneAsync("Shapes");
        /*TopGameManager.Instance.wipe.gameObject.SetActive(false);*/
        TopGameManager.Instance.button.SetActive(true); //Enabling button

    }
    private void SetAnswers()
    {

    }

    public void Correct()
    {
        StartCoroutine(CorrectFunction());
    }
    IEnumerator CorrectFunction()
    {
        yield return new WaitForSeconds(2);
        QnA.RemoveAt(0);
        questionNo[currentQuesrtion].SetActive(false);
        generateQuestion();
    }
    public void Wrong()
    {

    }
   

}
