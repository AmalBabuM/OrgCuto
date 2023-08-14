using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragManager : MonoBehaviour
{
    public DragDialogueController qstnController;
    public GameObject questionLoad;
    public GameObject shape,correctShape,wrongShape1,wrongShape2;
    public GameObject replacingShape,correctLight,wrongLight1,wrongLight2;

    Vector3 initialShapePosition, initialWrongShape1, initialWrongShape2, initialChrysalisPosition, initialEggPosition;

    bool butterflyBool, carBool, caterpillarBool, chrysalisBool, eggBool = false;

    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;

    void Start()
    {
        initialShapePosition = shape.transform.position;
        initialWrongShape1 = wrongShape1.transform.position;
        initialWrongShape2 = wrongShape2.transform.position;
       /* initialChrysalisPosition = chrysalis.transform.position;
        initialEggPosition = egg.transform.position;*/

    }

    public void DragButterfly()
    {


        shape.transform.position = Input.mousePosition;

    }


    public void DropButterfly()
    {

        float correctDistance = Vector3.Distance(shape.transform.position, correctShape.transform.position);
        float wrongtDistance1 = Vector3.Distance(shape.transform.position, wrongShape1.transform.position);
        float wrongtDistance2 = Vector3.Distance(shape.transform.position, wrongShape2.transform.position);
        if (correctDistance < 50)
        {
            /* butterfly.transform.position = butterflyBlack.transform.position;
             Score.scoreNumber += 1;
             butterflyBool = true;
             source.clip = correct[Random.Range(0, correct.Length)];
             source.Play();*/

            shape.transform.position = correctShape.transform.position;
            shape.active = false;
            /*correctButterfly.active = true;*/
            correctLight.SetActive(true);
            Score.scoreNumber += 1;
            butterflyBool = true;
            source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();
            //Play next Question
            StartCoroutine(SceneChange());
           /* qstnController.NextOne();*/

        }
        else if(wrongtDistance1 < 50)
        {
            Debug.Log("Wrong Shape1");
            shape.transform.position = initialShapePosition;
            replacingShape.active = false;
            wrongLight1.SetActive(true);
            source.clip = incorrect;
            source.Play();
        }
        else if(wrongtDistance2 < 50)
        {
            Debug.Log("Wrong Shape2");
            shape.transform.position = initialShapePosition;
            replacingShape.active = false;
            wrongLight2.SetActive(true);
            source.clip = incorrect;
            source.Play();
        }
        else

        {
            shape.transform.position = initialShapePosition;
            replacingShape.active = false;
            source.clip = incorrect;
            source.Play();
        }




    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(1.0f);
        qstnController.NextOne();
        if(questionLoad!=null)
        questionLoad.SetActive(true);
        gameObject.SetActive(false);
    }

   /* void Update()
    {
        if (butterflyBool || Timer.time <= 0)
        {
            Debug.Log("Level completed");
            *//*TopGameManager.Instance.Level[0].SetActive(false);*/
            /*GoButton.OnState?.Invoke(0);*/
           
            /*TopGameManager.Instance.button.SetActive(true); //Enabling button
            SceneManager.UnloadSceneAsync("Butterfly");*/
           
            /* TopGameManager.Instance.button.SetActive(true);*/
            /*StartCoroutine(LoadNextScene());*//*
        }
    }*/

    IEnumerator LoadNextScene()
    {
       /* blockPanel.SetActive(true);*/
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
