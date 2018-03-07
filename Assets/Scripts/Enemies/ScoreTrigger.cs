using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public int scoreValue = 10;
    public ScoreScript scoreScript;

    private void OnTriggerExit2D(Collider2D collision)
    {
        scoreScript.UpdateScore(scoreValue);
    }
}
