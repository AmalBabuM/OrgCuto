using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static UnityAction<int> OnState;
    public float moveSpeed = 5f;
    private bool isMovingForward = false;
    public enum PlayerState { idle, walking, talking }

    public PlayerState state;
    

    private CharacterController characterController;
    private Animator anim;

    private void OnEnable()
    {
        OnState += Controll;
    }
    private void Start()
    {
        
        characterController = GetComponentInParent<CharacterController>();
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (isMovingForward)
        {
            Vector3 movement = transform.forward * moveSpeed * Time.deltaTime;
            characterController.Move(movement);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isMovingForward = true;
        WalkState();
    }

    private void OnDisable()
    {
        /* Debug.Log("Disabled");*/
        /* OnState -= Controll;*/
        isMovingForward = false;
        /*IdleState();*/
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isMovingForward = false;
        IdleState();
    }
    void IdleState()
    {
        Debug.Log("Idle state");
        Controll(0);
    }
    void WalkState()
    {
        Controll(1);
    }
    public void TalkState()
    {
        
        Controll(2);
    }
    void Controll(int currentCount)
    {
        
        if (currentCount == 0)
        {
            state = PlayerState.idle;
        }
        else if (currentCount == 1)
        {
            state = PlayerState.walking;
        }
        else if (currentCount == 2)
        {
            state = PlayerState.talking;
        }

        anim.SetInteger("Status", (int)state);
    }

}
