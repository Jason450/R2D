using System.Collections;
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
        maxScoreText.text = "MAX SCORE: " + maxScore.ToString("D4");

        if(score > maxScore)
        {
            maxScore = score;
            maxScoreText.text = "MAX SCORE: " + maxScore.ToString("D4");
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
}
