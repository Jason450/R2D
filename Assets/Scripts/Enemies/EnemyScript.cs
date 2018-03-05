using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public Transform enemy;
    private Vector2 enemyPos;

	void Start ()
    {
        enemyPos = new Vector2(enemy.position.x, enemy.position.y);
	}
	
	void Update ()
    {
        enemyPos.x -= speed * Time.deltaTime;
        enemy.position = new Vector3(enemyPos.x, enemyPos.y, 0);

        if (enemyPos.x <= -10) enemyPos.x = 10;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
