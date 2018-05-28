using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMaster : MonoBehaviour
{
    BounceGroup mainMenu;
    BounceGroup optionsMenu;

    void Start ()
    {
        mainMenu = GameObject.Find("MainMenu").GetComponent<BounceGroup>();
        optionsMenu = GameObject.Find("OptionsMenu").GetComponent<BounceGroup>();
    }

    void Update ()
    {

    }

    public void BackToMain()
    {
        mainMenu.start = 500;
        mainMenu.end = 0;
        mainMenu.Active = true;

        optionsMenu.start = 0;
        optionsMenu.end = 500;
        optionsMenu.Active = true;
    }

    public void GoToOptions()
    {
        mainMenu.start = 0;
        mainMenu.end = 500;
        mainMenu.Active = true;

        optionsMenu.start = 500;
        optionsMenu.end = 0;
        optionsMenu.Active = true;
    }
    
}
