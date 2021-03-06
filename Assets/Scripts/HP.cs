using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public Slider slider;

    public int maxHealth = 100;
    public int currentHealth;

    public Gradient gradient;
    public Image fill;


    void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }

    void Update()
    {
        SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("GameOver");
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        //Grandient Slider Color
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }
    
}
