﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    public Text maxScoreText;
    public int score;
    public int maxScore;

	void Start ()
    {
        score = 0;
	}
	
	void Update ()
    {
        scoreText.text = "SCORE: " + score.ToString("D4");
        maxScoreText.text = "HI-SCORE: " + maxScore.ToString("D4");

        if(score > maxScore)
        {
            maxScore = score;
            maxScoreText.text = "HI-SCORE: " + maxScore.ToString("D4");
        }
    }

    public void UpdateScore(int _score)
    {
        score += _score;
    }

    public void UpdateMaxScore(int _maxScore)
    {
        maxScore = _maxScore;
    }

    public void Reset()
    {
        score = 0;
    }
}
