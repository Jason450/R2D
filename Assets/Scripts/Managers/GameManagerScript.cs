using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject mainMenu;
    //public GameObject playButton;
    //public GameObject optionsButton;
    //public GameObject exitButton;
    [Header("Options Menu")]
    public GameObject optionsMenu;
    [Header("Screen Transition")]
    public GameObject transition;
    [Header("Transition Audio")]
    public AudioSource sound;

    public float counter;
    public bool starting;

    void Start ()
    {
        mainMenu = GameObject.Find("Main Menu");
        optionsMenu = GameObject.Find("Options Menu");
        optionsMenu.SetActive(false);

        counter = 2;
        starting = false;
    }
	
	void Update ()
    {
        if (starting)
        {
            counter -= Time.deltaTime;

            if (counter <= 0) LoadGameplay();
        }

        if (Input.GetKeyDown(KeyCode.V)) sound.Play();
    }

    public void Transition()
    {
        sound.Play();
        starting = true;
        transition.SetActive(true);
    }

    public void LoadGameplay()
    {
        SceneManager.LoadScene(2);
    }

    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
