using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject mainMenu;
    [Header("Options Menu")]
    public BounceGroup optionsPanel;
    public GameObject optionsMenu;
    [Header("Screen Transition")]
    public GameObject transition;
    [Header("Transition Audio")]
    public AudioSource button;
    public AudioSource title;
    public AudioSource menu;

    public float counter;
    public float sliderCounter;
    public float soundCounter;
    public bool starting;
    public bool slider;
    public bool titleSound;
    public bool menuSound;

    void Start ()
    {
        mainMenu = GameObject.Find("Main Menu");
        optionsMenu = GameObject.Find("Options Menu");
        //optionsMenu.SetActive(false);

        counter = 2;
        sliderCounter = 0.2f;
        soundCounter = 2f;
        starting = false;
        slider = false;
        titleSound = true;
        menuSound = true;
    }
	
	void Update ()
    {
        if (titleSound)
        {
            soundCounter -= Time.deltaTime;
            if (soundCounter <= 0.5)
            {
                titleSound = false;
                title.Play();
            }
        }
        if (menuSound)
        {
            soundCounter -= Time.deltaTime;
            if (soundCounter <= 0)
            {
                menuSound = false;
                menu.Play();
            }
        }
        if (starting)
        {
            counter -= Time.deltaTime;

            if (counter <= 0) LoadGameplay();
        }

        if (slider)
        {
            sliderCounter -= Time.deltaTime;
            if (sliderCounter <= 0)
            {
                slider = false;
                sliderCounter = 0.2f;
                button.Play();
            }
        }
    }

    public void Transition()
    {
        starting = true;
        transition.SetActive(true);
    }

    public void ButtonSound()
    {
        button.Play();
    }

    public void SliderSound()
    {
        slider = true;
    }

    public void LoadGameplay()
    {
        SceneManager.LoadScene(2);
    }

    public void OptionsMenu()
    {
        //mainMenu.SetActive(false);
        //optionsMenu.SetActive(true);
        optionsPanel.start = 1080;
        optionsPanel.end = 0;
        optionsPanel.Active = true;
    }

    public void BackToMainMenu()
    {
        //mainMenu.SetActive(true);
        //optionsMenu.SetActive(false);
        optionsPanel.start = 0;
        optionsPanel.end = 1080;
        optionsPanel.Active = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
