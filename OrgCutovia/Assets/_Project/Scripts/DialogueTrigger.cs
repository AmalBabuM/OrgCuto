using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Cinemachine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    private InterfaceManager ui;
    private VillagerScript currentVillager;
    private MovementInput movement;
    public CinemachineTargetGroup targetGroup;


    [Space]

    [Header("Post Processing")]
    public Volume dialogueDof;

    void Start()
    {
        ui = InterfaceManager.instance;
        movement = GetComponent<MovementInput>();
    }

    /* void Update()
     {
         if (Input.GetKeyDown(KeyCode.Space) && !ui.inDialogue && currentVillager != null)
         {
             targetGroup.m_Targets[1].target = currentVillager.transform;
             movement.active = false;
             ui.SetCharNameAndColor();
             ui.inDialogue = true;
             ui.CameraChange(true);
             ui.ClearText();
             ui.FadeUI(true, .2f, .65f);
             currentVillager.TurnToPlayer(transform.position);
         }
     }*/

    /*void PlayDialogue()
    {
        if (!ui.inDialogue && currentVillager != null)
        {
            targetGroup.m_Targets[1].target = currentVillager.transform;
            movement.active = false;
            ui.SetCharNameAndColor();
            ui.inDialogue = true;
            ui.CameraChange(true);
            ui.ClearText();
            ui.FadeUI(true, .2f, .65f);
            currentVillager.TurnToPlayer(transform.position);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Villager"))
        {
            currentVillager = other.GetComponent<VillagerScript>();
            ui.currentVillager = currentVillager;
            StartCoroutine(UpCall());
            
            /*ui.goButton.SetActive(false);*/
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Villager"))
        {
            currentVillager = null;
            ui.currentVillager = currentVillager;
        }
    }

    IEnumerator UpCall()
    {
        while (true)
        {
            if(currentVillager == null||currentVillager.GetComponent<BoxCollider>().enabled==false)
            {
                /*GoButton.OnState?.Invoke(0);*/
                break;
            }
           
            if (!ui.inDialogue && currentVillager != null)
            {
               
                targetGroup.m_Targets[1].target = currentVillager.transform;
                movement.active = false;
               /* ui.SetCharNameAndColor();*/
                ui.inDialogue = true;
                ui.CameraChange(true);
                ui.ClearText();
                ui.FadeUI(true, .2f, .65f);
                currentVillager.TurnToPlayer(transform.position);
            }
            yield return new WaitForSeconds(5f);
            ui.PlayNext();
        }
    }
}
