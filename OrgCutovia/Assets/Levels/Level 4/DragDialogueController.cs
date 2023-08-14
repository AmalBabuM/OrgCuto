using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDialogueController : MonoBehaviour
{
    public StoryScene currentScene;
    public TopBarController topBar;
    public GameObject dialogueBar;
    /*public GameObject questionBar;
    public GameObject quizmanager;
    public GameObject shapeGameObject;*/
    // Start is called before the first frame update
    void Start()
    {
        topBar.PlayScene(currentScene);
    }

    // Update is called once per frame
   /* void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (topBar.IsCompleted())
            {
                if (topBar.IsLastSentence())
                {
                    if (currentScene.nextScene == null)
                    {
                        Debug.Log("No more scene");
                        dialogueBar.SetActive(false);
                        *//*shapeGameObject.SetActive(false);
                        questionBar.SetActive(true);
                        quizmanager.SetActive(true);*//*
                    }
                    else
                    {
                        currentScene = currentScene.nextScene;
                        topBar.PlayScene(currentScene);
                    }
                }
                else
                    topBar.PlayNextScene();
            }
        }
    }*/
    public void NextOne()
    {
        if (topBar.IsCompleted())
        {
            if (topBar.IsLastSentence())
            {
                if (currentScene.nextScene == null)
                {
                    Debug.Log("No more scene");
                    dialogueBar.SetActive(false);
                    /*shapeGameObject.SetActive(false);
                    questionBar.SetActive(true);
                    quizmanager.SetActive(true);*/
                }
                else
                {
                    currentScene = currentScene.nextScene;
                    topBar.PlayScene(currentScene);
                }
            }
            else
                topBar.PlayNextScene();
        }
    }
}
