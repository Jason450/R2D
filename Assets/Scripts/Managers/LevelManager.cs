using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ScoreScript scoreScript;
    public PlayerScript player;
    public EnemyScript enemy;
    public GameObject endingScreen;
    public int maxScore;
    public bool playingLevel = true;
    public bool lvlEnded = false;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        //scoreScript.UpdateScore(maxScore);
        if (playingLevel)
        {
            endingScreen.SetActive(false);
            player.gameObject.SetActive(true);
            enemy.gameObject.SetActive(true);
            Time.timeScale = 1;
        }

        if (lvlEnded)
        {
            //enemy.Reset();
            endingScreen.SetActive(true);
            player.gameObject.SetActive(false);
            enemy.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
	}

    public void StartLevel()
    {
        scoreScript.Reset();
        player.life = 1;
        playingLevel = true;
        lvlEnded = false;
    }

    public void FinishLevel()
    {
        playingLevel = false;
        lvlEnded = true;
    }
}
