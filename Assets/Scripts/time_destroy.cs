using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time_destroy : MonoBehaviour
{
    private float timerDestroy = 1f;

    void Start()
    {
        Destroy(gameObject, timerDestroy);
    }

   
}
