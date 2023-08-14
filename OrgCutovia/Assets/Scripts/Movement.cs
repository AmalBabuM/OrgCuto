using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum PlayerState { idle, walking, pickup }

    public PlayerState state;
    int currentCount = 0;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame

    void Update()
    {

        /*if(Input.GetKeyDown(KeyCode.M))
        {
           *//* Debug.Log(currentCount);*//*
            currentCount++;
            if(currentCount > 1)
            {
                currentCount = 0;
            }
            Controll();
        }*/
        if (Input.GetKey(KeyCode.W))
        {
            currentCount = 1;
            Controll();
        }
        else if(!Input.GetKey(KeyCode.W))
        {
            currentCount = 0;
            Controll();
        }

    }

    void Controll()
    {
        if(currentCount==0)
        {
            state = PlayerState.idle;
        }
        else if(currentCount==1)
        {
            state = PlayerState.walking;
        }
        else if (currentCount == 2)
        {
            state = PlayerState.pickup;
        }

        anim.SetInteger("Status",(int)state);
    }

}
