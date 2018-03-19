using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Other Scripts")]
    public PlayerScript player;
    [Header("Stats")]
    public bool canMove;
    public float speed;
    public int damage = 1;
    [Header("Physics")]
    public Transform enemy;
    private Vector2 enemyPos;

	void Start ()
    {
        canMove = true;
        enemyPos = new Vector2(10, enemy.position.y);
	}
	
	void Update ()
    {
        if (canMove)
        {
            speed += 0.1f * Time.deltaTime;
            enemyPos.x -= speed * Time.deltaTime;
            enemy.position = new Vector3(enemyPos.x, enemyPos.y, 0);
        }

        if (enemyPos.x <= -10)
        {
            enemyPos.x = Random.Range(10, 15);
            Debug.Log(enemyPos.x);
        }

        if (speed >= 15) speed = 15;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.RecieveDamage(damage);
        Reset();
    }

    public void Reset()
    {
        enemyPos = new Vector2(10, enemy.position.y);
    }
}
