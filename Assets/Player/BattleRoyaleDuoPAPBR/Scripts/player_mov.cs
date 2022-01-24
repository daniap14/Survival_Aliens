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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            playerAnimator.SetBool("shoot", true);

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnimator.SetBool("walk", true);

        }

      




    }
}
