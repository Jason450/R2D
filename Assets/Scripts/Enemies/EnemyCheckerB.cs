using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckerB : MonoBehaviour
{
    public EnemyScript enemy;

    private void OnTriggerStay2D(Collider2D collision)
    {
        enemy.canMove = false;
        Debug.Log(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy.canMove = true;
    }
}
