using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteScene : MonoBehaviour
{
    private void Start()
    {
        SceneManager.UnloadSceneAsync("SampleAssets");
        Debug.Log("Deleted");
    }
}
