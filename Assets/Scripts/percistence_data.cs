using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class percistence_data : MonoBehaviour
{
    public float scoreData;
    public static percistence_data sharedInstance;
    public void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(this);
        }

        else { Destroy(gameObject); }
    }
}
