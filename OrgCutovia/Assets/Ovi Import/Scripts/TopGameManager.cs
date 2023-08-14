using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopGameManager : MonoBehaviour
{
    public GameObject Cam;
    public GameObject eventSystem;
    public static TopGameManager Instance;
    public GameObject button;
    public WipeController wipe;

    
    public GameObject[] Level;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void TransOff()
    {
        StartCoroutine(StopTrans());
    }
    IEnumerator StopTrans()
    {
        yield return new WaitForSeconds(1);
        TopGameManager.Instance.wipe.gameObject.SetActive(false);

    }

}
