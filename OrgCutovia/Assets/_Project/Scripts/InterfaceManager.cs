using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Rendering;
using Cinemachine;

using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    
    public bool inDialogue;
    /*public GameObject goButton;*/

    public static InterfaceManager instance;

    /*public CanvasGroup canvasGroup;*/
    public TMP_Animated animatedText;
    /*public Image nameBubble;
    public TextMeshProUGUI nameTMP;*/

    [HideInInspector]
    public VillagerScript currentVillager;

    private int dialogueIndex;
    public bool canExit;
    public bool nextDialogue;

    [Space]

    [Header("Cameras")]
    public GameObject gameCam;
    public GameObject dialogueCam;

    [Space]

    public Volume dialogueDof;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
        animatedText.onDialogueFinish.AddListener(() => FinishDialogue());
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inDialogue)
        {
            if (canExit)
            {
                CameraChange(false);
                FadeUI(false, .2f, 0);
                Sequence s = DOTween.Sequence();
                s.AppendInterval(.8f);
                s.AppendCallback(() => ResetState());
            }

            if (nextDialogue)
            {
                animatedText.ReadText(currentVillager.dialogue.conversationBlock[dialogueIndex]);
            }
        }
    }*/
    public void PlayNext()
    {
        if (inDialogue)
        {
           
            if (canExit)
            {
                
                CameraChange(false);
                FadeUI(false, .2f, 0);
                Sequence s = DOTween.Sequence();
                s.AppendInterval(.8f);
                s.AppendCallback(() => ResetState());
                /*currentVillager.level.SetActive(true);// levels gets activated*/
                
                StartCoroutine (TransitionLoad());
                currentVillager.GetComponent<BoxCollider>().enabled = false;
                TopGameManager.Instance.wipe.AnimatorOut();

                GoButton.OnState?.Invoke(0);   //Player Idle state is enabled
                Debug.Log("Finished");
                
            }

            if (nextDialogue)
            {
                animatedText.ReadText(currentVillager.dialogue.conversationBlock[dialogueIndex]);
                /*Debug.Log("Next");*/
            }
        }
    }
    IEnumerator TransitionLoad()
    {
        TopGameManager.Instance.wipe.gameObject.SetActive(true);
        yield return null;
        TopGameManager.Instance.wipe.AnimatorIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(currentVillager.sceneName, LoadSceneMode.Additive);
        yield return new WaitForSeconds(1);
        TopGameManager.Instance.wipe.gameObject.SetActive(false);
    }

    public void FadeUI(bool show, float time, float delay)
    {
        Sequence s = DOTween.Sequence();
        s.AppendInterval(delay);
        /*s.Append(canvasGroup.DOFade(show ? 1 : 0, time));*/
        if (show)
        {
            dialogueIndex = 0;
           /* s.Join(canvasGroup.transform.DOScale(0, time * 2).From().SetEase(Ease.OutBack));*/
            s.AppendCallback(() => animatedText.ReadText(currentVillager.dialogue.conversationBlock[0]));
        }
    }

    /*public void SetCharNameAndColor()
    {
        nameTMP.text = currentVillager.data.villagerName;
        nameTMP.color = currentVillager.data.villagerNameColor;
        nameBubble.color = currentVillager.data.villagerColor;

    }*/

    public void CameraChange(bool dialogue)
    {
        gameCam.SetActive(!dialogue);
        dialogueCam.SetActive(dialogue);

        //Depth of field modifier
        float dofWeight = dialogueCam.activeSelf ? 1 : 0;
        DOVirtual.Float(dialogueDof.weight, dofWeight, .8f, DialogueDOF);
    }

    public void DialogueDOF(float x)
    {
        dialogueDof.weight = x;
    }

    public void ClearText()
    {
        animatedText.text = string.Empty;
        Debug.Log("Clear");
       
        Debug.Log("Over");
    }

    public void ResetState()
    {
        currentVillager.Reset();
        FindObjectOfType<MovementInput>().active = true;
        inDialogue = false;
        
        canExit = false;
       /* goButton.SetActive(true);*/
    }

    public void FinishDialogue()
    {
        if (dialogueIndex < currentVillager.dialogue.conversationBlock.Count - 1)
        {
            dialogueIndex++;
            nextDialogue = true;
        }
        else
        {
            nextDialogue = false;
            canExit = true;
        }
    } 
}
