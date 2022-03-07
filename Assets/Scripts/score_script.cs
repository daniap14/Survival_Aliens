using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score_script : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
   

    void Update()
    {
        
        scoreText.SetText($"Score: {percistence_data.sharedInstance.scoreData}");
        
    }

}
