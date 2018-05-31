using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [Header("Canvas Groups")]
    public BounceGroup pauseGroup;
    public BounceGroup endingGroup;

    void Start ()
    {
        player.life = 1;
        lvlEnded = false;
        pause = false;
        scoreScript.maxScore =  PlayerPrefs.GetInt("maxScore");
    }

    void Update ()
    {
        
	}

    public void StartLevel()
    {
        scoreScript.Reset();
        playingLevel = true;
        lvlEnded = false;
        player.gameObject.SetActive(true);
        player.life = 1;
        EndingGroupOff();
    }

    public void FinishLevel()
    {
        sound.Play();
        playingLevel = false;
        lvlEnded = true;
        player.gameObject.SetActive(false);
        EndingGroupOn();
        PlayerPrefs.SetInt("maxScore", scoreScript.maxScore);
    }

    public void Pause()
    {
        pause = !pause;

        if (pause)
        {
            Time.timeScale = 0;
            PauseGroupOn();
        }
        else
        {
            Time.timeScale = 1;
            PauseGroupOff();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGroupOn()
    {
        pauseGroup.start = 1000;
        pauseGroup.end = -100;
        pauseGroup.Active = true;
    }

    public void PauseGroupOff()
    {
        pauseGroup.start = -100;
        pauseGroup.end = 1000;
        pauseGroup.Active = true;
    }

    public void EndingGroupOn()
    {
        endingGroup.start = 1000;
        endingGroup.end = -100;
        endingGroup.Active = true;
    }

    public void EndingGroupOff()
    {
        endingGroup.start = -100;
        endingGroup.end = 1000;
        endingGroup.Active = true;
    }
}
