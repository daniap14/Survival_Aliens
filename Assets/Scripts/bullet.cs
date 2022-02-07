using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float timerDestroy = 1f;

    void Start()
    {

       
        Destroy(gameObject, timerDestroy);


    }

    public void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            Destroy(otherCollider.gameObject);
            

        }
       
    }
}
