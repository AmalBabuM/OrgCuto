using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButterflyManager : MonoBehaviour
{
    public GameObject butterfly, car, caterpillar, chrysalis, egg, butterflyBlack, carBlack, caterpillarBlack, chrysalisBlack, eggBlack, blockPanel;
    public GameObject correctButterfly, correctCaterpillar, correctChrysalis, correctEgg;

    Vector3 initialButterflyPosition, initialCarPosition, initialCaterpillarPosition, initialChrysalisPosition, initialEggPosition;

    bool butterflyBool, carBool, caterpillarBool, chrysalisBool, eggBool = false;

    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;



    public GameObject PausePanel;
    public static bool gameIsPaused;

    void Start()
    {
        initialButterflyPosition = butterfly.transform.position;
        initialCarPosition = car.transform.position;
        initialCaterpillarPosition = caterpillar.transform.position;
        initialChrysalisPosition = chrysalis.transform.position;
        initialEggPosition = egg.transform.position;

    }





    public void DragButterfly()
    {


        butterfly.transform.position = Input.mousePosition;

    }


    public void DragCar()
    {


        car.transform.position = Input.mousePosition;

    }

    public void DragCaterpillar()
    {


        caterpillar.transform.position = Input.mousePosition;

    }

    public void DragChrysalis()
    {


        chrysalis.transform.position = Input.mousePosition;

    }

    public void DragEgg()
    {

        egg.transform.position = Input.mousePosition;

    }








    public void DropButterfly()
    {

        float distance = Vector3.Distance(butterfly.transform.position, butterflyBlack.transform.position);
        if (distance < 50)
        {
            /* butterfly.transform.position = butterflyBlack.transform.position;
             Score.scoreNumber += 1;
             butterflyBool = true;
             source.clip = correct[Random.Range(0, correct.Length)];
             source.Play();*/

            butterfly.transform.position = butterflyBlack.transform.position;
            butterfly.active = false;
            correctButterfly.active = true;
            Score.scoreNumber += 1;
            butterflyBool = true;
            source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();

        }
        else

        {
            butterfly.transform.position = initialButterflyPosition;
            correctButterfly.active = false;
            source.clip = incorrect;
            source.Play();
        }




    }

    public void DropCar()
    {

        float distance = Vector3.Distance(car.transform.position, carBlack.transform.position);
        if (distance < 65)
        {
            car.transform.position = carBlack.transform.position;
            Score.scoreNumber += 1;
            carBool = true;
            source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();
        }
        else
        {
            car.transform.position = initialCarPosition;
            source.clip = incorrect;
            source.Play();
        }

    }

    public void DropCaterpillar()
    {

        float distance = Vector3.Distance(caterpillar.transform.position, caterpillarBlack.transform.position);
        if (distance < 65)
        {
            correctCaterpillar.active = true;
            caterpillar.active = false;
            caterpillar.transform.position = caterpillarBlack.transform.position;
            Score.scoreNumber += 1;
            caterpillarBool = true;
            source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();
        }
        else
        {
            correctCaterpillar.active = false;
            caterpillar.transform.position = initialCaterpillarPosition;
            source.clip = incorrect;
            source.Play();
        }

    }


    public void DropChrysalis()
    {

        float distance = Vector3.Distance(chrysalis.transform.position, chrysalisBlack.transform.position);
        if (distance < 65)
        {
            correctChrysalis.active = true;
            chrysalis.active=false;
            chrysalis.transform.position = chrysalisBlack.transform.position;
            chrysalis.transform.localScale = chrysalisBlack.transform.localScale;
            Score.scoreNumber += 1;
            chrysalisBool = true;
            source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();
        }
        else
        {
            correctChrysalis.active = false;
            chrysalis.transform.position = initialChrysalisPosition;
            source.clip = incorrect;
            source.Play();
        }



    }
    public void DropEgg()
    {

        float distance = Vector3.Distance(egg.transform.position, eggBlack.transform.position);
        if (distance < 65)
        {
            correctEgg.active=true;
            egg.active=false;
            egg.transform.position = eggBlack.transform.position;
            Score.scoreNumber += 1;
            eggBool = true;
            source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();
        }
        else
        {
            correctEgg.active = false;
            egg.transform.position = initialEggPosition;
            source.clip = incorrect;
            source.Play();
        }



    }


    void Update()
    {
        if (butterflyBool && caterpillarBool && chrysalisBool && eggBool || Timer.time <= 0)
        {
            Debug.Log("Level completed");
            /*TopGameManager.Instance.Level[0].SetActive(false);*/
            /*GoButton.OnState?.Invoke(0);*/
            TopGameManager.Instance.button.SetActive(true); //Enabling button
            SceneManager.UnloadSceneAsync("Butterfly");
           /* TopGameManager.Instance.button.SetActive(true);*/
            /*StartCoroutine(LoadNextScene());*/
        }
    }

    IEnumerator LoadNextScene()
    {
        blockPanel.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    public void Setting()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }


    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
