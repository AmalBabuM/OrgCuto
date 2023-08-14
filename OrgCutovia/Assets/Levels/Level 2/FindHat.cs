using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindHat : MonoBehaviour
{
    public GameObject child;
    public GameObject realObject;
    public GameObject correctAnswer;
    public GameObject wrongAnswer;
    static bool isClickable=true;
    
    private void OnMouseDown()
    {
        if (isClickable)
        {
            isClickable = false;
            child.SetActive(false);
            realObject.SetActive(true);
            gameObject.GetComponent<SphereCollider>().enabled = false;

            if(realObject.CompareTag("Hat"))
            {
                correctAnswer.SetActive(true);
                StartCoroutine(CheckAnswer());
            }
            else
            {
                wrongAnswer.SetActive(true) ;
                StartCoroutine(CheckAnswer());
            }
            
        }
    }

    IEnumerator CheckAnswer()
    {
        yield return new WaitForSeconds(4f);
        if (realObject.tag == "Hat")
        {
            Debug.Log("hat found");
        /*SceneManager.LoadScene("SampleAssets");*/
           
        /*TopGameManager.Instance.button.SetActive(true); //Enabling button*/
        }
        realObject.SetActive(false) ;
        wrongAnswer.SetActive(false);
        correctAnswer.SetActive(false);
        isClickable = true;
    }

}
