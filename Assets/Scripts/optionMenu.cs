using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject options;

    public void OptionsButton()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }
    public void ExitOptionsButton()
    {
        menu.SetActive(true);
        options.SetActive(false);
    }

}
