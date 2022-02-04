using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class game_manager : MonoBehaviour
{
    public float damage = -20f;

    void Start()
    {
       
    }
    public void OnMouseDown()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            // enemy_move eHealth = gameObject.GetComponent<enemy_move>();
            // eHealth.AdjustCurrentHealth(damage);
            Destroy(gameObject);
        }
        
    }
}
