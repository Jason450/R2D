using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Score")]
    public ScoreScript scoreScript;
    public int maxScore;
    [Header("Player")]
    public PlayerScript player;
    [Header("Enemies")]
    public EnemyScript enemy;
    public Enemy2Script enemy2;
    [Header("Clouds")]
    public CloudScript cloud01;
    public CloudScript cloud02;
    public CloudScript cloud03;
    public CloudScript cloud04;
    public CloudScript cloud05;
    public CloudScript cloud06;
    public CloudScript cloud07;
    [Header("Ground")]
    public GroundScript ground;
    [Header("Menu Screens")]
    public GameObject pauseScreen;
    public GameObject endingScreen;
    [Header("Audio")]
    public AudioSource sound;
    [Header("Level States")]
    public bool playingLevel;
    public bool lvlEnded;
    public bool pause;

	void Start ()
    {
        player.life = 1;
        playingLevel = true;
        lvlEnded = false;
        pause = false;
        scoreScript.maxScore =  PlayerPrefs.GetInt("maxScore");
    }

    void Update ()
    {
        cloud01.PlayingLevel(playingLevel);
        cloud02.PlayingLevel(playingLevel);
        cloud03.PlayingLevel(playingLevel);
        cloud04.PlayingLevel(playingLevel);
        cloud05.PlayingLevel(playingLevel);
        cloud06.PlayingLevel(playingLevel);
        cloud07.PlayingLevel(playingLevel);

        ground.PlayingLevel(playingLevel);

        if (playingLevel)
        {
            pauseScreen.SetActive(false);
            endingScreen.SetActive(false);
            player.gameObject.SetActive(true);
            enemy.gameObject.SetActive(true);
        }

        if (lvlEnded)
        {
            enemy.Reset();
            enemy2.Reset();
            ground.Reset();
            endingScreen.SetActive(true);
            player.gameObject.SetActive(false);
            enemy.gameObject.SetActive(false);
            PlayerPrefs.SetInt("maxScore", scoreScript.maxScore);
        }

        if (pause)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
	}

    public void StartLevel()
    {
        scoreScript.Reset();
        player.life = 1;
        playingLevel = true;
        lvlEnded = false;
        pause = false;
    }

    public void FinishLevel()
    {
        sound.Play();
        playingLevel = false;
        lvlEnded = true;
    }

    public void Unpause()
    {
        playingLevel = true;
        pause = false;
    }

    public void Pause()
    {
        pause = !pause;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
