using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public GameObject[] objectsToToggle;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < objectsToToggle.Length; i++)
        {
            objectsToToggle[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Disable the current active game object
            objectsToToggle[currentIndex].SetActive(false);

            // Increment the index and wrap around if necessary
            currentIndex = (currentIndex + 1) % objectsToToggle.Length;

            // Enable the next game object
            objectsToToggle[currentIndex].SetActive(true);
        }
    }
   
}
