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
    public List<EnemyScript> enemy01;
    public List<Enemy2Script> enemy02;
    public BossScript boss;
    [Header("Clouds")]
    public CloudScript cloud01;
    public CloudScript cloud02;
    public CloudScript cloud03;
    public CloudScript cloud04;
    public CloudScript cloud05;
    public CloudScript cloud06;
    public CloudScript cloud07;
    //[Header("Ground")]
    //public GroundScript ground;
    [Header("Menu Screens")]
    public BounceGroup pauseGroup;
    public BounceGroup endingGroup;
    [Header("Audio")]
    public AudioSource sound;
    public AudioSource music;
    public AudioSource lose;
    [Header("Level States")]
    public bool playingLevel;
    public bool lvlEnded;
    public bool pause;
    public float timeToBoss;
    public bool bossActive;

    void Start ()
    {
        player.life = 1;
        lvlEnded = false;
        pause = false;
        scoreScript.maxScore =  PlayerPrefs.GetInt("maxScore");
        for (int i = 0; i < enemy01.Count; i++)
        {
            enemy01[i].Reset();
        }
        for (int i = 0; i < enemy02.Count; i++)
        {
            enemy02[i].Reset();
        }
        timeToBoss = 30;
    }

    void Update ()
    {
        if (!bossActive) timeToBoss -= Time.deltaTime;
        if (timeToBoss <= 0)
        {
            timeToBoss = 30;
            bossActive = true;
            boss.active = true;
            for (int i = 0; i < enemy02.Count; i++)
            {
                enemy02[i].RecieveDamage(2);
                enemy02[i].canMove = false;
            }
        }
        if (boss.active == false)
        {
            bossActive = false;
            for (int i = 0; i < enemy02.Count; i++)
            {
                enemy02[i].canMove = true;
            }
        }
	}

    public void StartLevel()
    {
        Time.timeScale = 1;
        scoreScript.Reset();
        playingLevel = true;
        lvlEnded = false;
        player.gameObject.SetActive(true);
        player.life = 1;
        EndingGroupOff();
        for (int i = 0; i < enemy01.Count; i++)
        {
            enemy01[i].Reset();
        }
        for (int i = 0; i < enemy02.Count; i++)
        {
            enemy02[i].Reset();
        }
        boss.Reset();
        bossActive = false;
        timeToBoss = 30;
        lose.Stop();
        music.Play();
    }

    public void FinishLevel()
    {
        Time.timeScale = 0;
        sound.Play();
        lose.Play();
        music.Stop();
        playingLevel = false;
        lvlEnded = true;
        player.gameObject.SetActive(false);
        EndingGroupOn();
        PlayerPrefs.SetInt("maxScore", scoreScript.maxScore);
    }

    public void Pause()
    {
        if (player.life !=0)
        {
            pause = !pause;

            if (pause)
            {
                music.Pause();
                Time.timeScale = 0;
                PauseGroupOn();
                Debug.Log("ON");

            }
            else
            {
                music.UnPause();
                Time.timeScale = 1;
                PauseGroupOff();
                Debug.Log("OFF");
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGroupOn()
    {
        Debug.Log("pause");
        //pauseGroup.gameObject.SetActive(true);
        pauseGroup.start = 1000;
        pauseGroup.end = -100;
        pauseGroup.Active = true;
    }

    public void PauseGroupOff()
    {
        pauseGroup.start = -100;
        pauseGroup.end = 1000;
        //pauseGroup.desired = 0.1f;
        pauseGroup.Active = true;
    }

    public void EndingGroupOn()
    {
        Debug.Log("ending");
        //endingGroup.gameObject.SetActive(true);
        endingGroup.start = 1000;
        endingGroup.end = -100;
        endingGroup.Active = true;
    }

    public void EndingGroupOff()
    {
        endingGroup.start = -100;
        endingGroup.end = 1000;
        //endingGroup.desired = 0.1f;
        endingGroup.Active = true;
    }
}
