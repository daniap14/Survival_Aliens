using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mov : MonoBehaviour
{

    private Animator playerAnimator;

    
    void Start()
    {

        playerAnimator = GetComponent<Animator>();

    }

    
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnimator.SetBool("walk", true);

           
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnimator.SetBool("walk", false);

        }


    }
}
