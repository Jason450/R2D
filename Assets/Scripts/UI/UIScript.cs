using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text scoreText;
    public int score;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        scoreText.text = "SCORE: " + score.ToString("D5");
	}

    public void UpdateScore(int _score)
    {
        score = _score;
    }
}
