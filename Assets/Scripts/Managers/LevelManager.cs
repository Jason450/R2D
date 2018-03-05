using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int score;
    public UIScript UI;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        UI.UpdateScore(score);
	}
}
