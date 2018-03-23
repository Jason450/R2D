using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject transition;
    public AudioSource sound;
    public float counter;
    public bool starting;

    void Start ()
    {
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
