using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public LevelManager lvlManager;

    private void OnTriggerExit2D(Collider2D collision)
    {
        lvlManager.score += 10;
    }
}
