using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	
	void Update ()
    {
		
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
