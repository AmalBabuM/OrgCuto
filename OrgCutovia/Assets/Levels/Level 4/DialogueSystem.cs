using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text particleText;
    public ParticleSystem message;


    private void OnEnable()
    {
        StartCoroutine(MessageStart());
    }
    IEnumerator MessageStart()
    {
        yield return new WaitForSeconds(2);
        particleText.text = "This shape is called rectangle";
        message.Play();
        yield return new WaitForSeconds(2);
        particleText.text = "can you tell me what shape it is ?";
        message.Play();
        yield return new WaitForSeconds(2);
        particleText.text = "This shapes is called circle";
        message.Play();
        yield return new WaitForSeconds(2);
        particleText.text = "This shape is called triangle";
        message.Play();
    }
}
