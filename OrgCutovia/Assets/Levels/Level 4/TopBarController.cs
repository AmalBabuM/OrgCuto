using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TopBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;
    public AudioSource audioSource;
    

    private int sentenceIndex = -1;
    private StoryScene currentScene;
    private State state=State.COMPLTED;
   
    private enum State
    {
        PLAYING, COMPLTED
    }
    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextScene(); 
    }
   
    public void PlayNextScene()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textureColor;
        audioSource.clip = currentScene.sentences[sentenceIndex].clip;
        audioSource.Play();
        
        /*img.sprite = currentScene.sentences[sentenceIndex].shape;
        img.SetNativeSize();*/
    }
    public bool IsCompleted()
    {
        return state == State.COMPLTED;
    }
    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }
    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;
        while(state!=State.COMPLTED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if(++wordIndex==text.Length)
            {
                state = State.COMPLTED;
                break;
            }
        }
    }
}
