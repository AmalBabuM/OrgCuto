using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public TopBarController topBar;
    public GameObject dialogueBar;
    public GameObject questionBar;
    public GameObject quizmanager;
    public GameObject shapeGameObject;
    // Start is called before the first frame update
    void Start()
    {
        topBar.PlayScene(currentScene);
        shapeGameObject.GetComponent<Image>().sprite = currentScene.shape;
        shapeGameObject.GetComponent<Image>().SetNativeSize();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            if(topBar.IsCompleted())
            {
                if(topBar.IsLastSentence())
                {
                    if(currentScene.nextScene==null)
                    {
                        Debug.Log("No more scene");
                        /* dialogueBar.SetActive(false);
                         shapeGameObject.SetActive(false);
                         questionBar.SetActive(true);
                         quizmanager.SetActive(true);*/
                        SceneManager.LoadScene("DragShapes");
                    }
                    else
                    {
                    currentScene = currentScene.nextScene; 
                    topBar.PlayScene(currentScene);
                    shapeGameObject.GetComponent<Image>().sprite = currentScene.shape;
                    shapeGameObject.GetComponent<Image>().SetNativeSize();
                    }
                }
                else
                topBar.PlayNextScene();
            }
        }
    }
}
