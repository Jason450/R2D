using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    public GameObject splash;
    public Animator anim;
    [Header("Other Scripts")]
    public PlayerScript player;
    public ScoreScript scoreScript;
    [Header("Stats")]
    public int maxLife;
    public int life;
    public bool canMove;
    public float speed;
    public int damage = 1;
    public int scoreValue = 10;
    [Header("Physics")]
    public Transform enemy;
    private Vector2 enemyPos;

    void Start()
    {
        life = maxLife;
        canMove = true;
        //enemyPos = new Vector2(15, enemy.position.y);
    }

    void Update()
    {
        if (canMove)
        {
            //speed += 0.1f * Time.deltaTime;
            enemyPos.x -= speed * Time.deltaTime;
        }
        enemy.position = new Vector3(enemyPos.x, enemyPos.y, 0);

        if (enemyPos.x <= -10)
        {
            Reset();
            //Debug.Log(enemyPos.x);
        }

        if(speed >= 15) speed = 15;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided");
        if (collision.gameObject.tag == "Player")
        {
            player.RecieveDamage(damage);
            Reset();
        }
    }

    public void RecieveDamage(int damage)
    {
        Debug.Log("enemy2 damaged?");
        life -= damage;
        if (life <= 0)
        {
            Instantiate(splash, new Vector3(this.transform.position.x, this.transform.position.y, 0), new Quaternion(0, 0, 0, 0));
            scoreScript.UpdateScore(scoreValue);
            Reset();
        }
    }

    public void Reset()
    {
        enemyPos = new Vector2((Random.Range(10, 20)), Random.Range(-1, 3));
        life = maxLife;
        //speed = 5;
    }
}
