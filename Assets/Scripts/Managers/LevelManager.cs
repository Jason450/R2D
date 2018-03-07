using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ScoreScript scoreScript;
    public PlayerScript player;
    public EnemyScript enemy;
    public int maxScore;
    public bool lvlEnded = false;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        //scoreScript.UpdateScore(maxScore);
        if(lvlEnded)
        {
            //player.
        }
	}
}
