using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public enum BossState { Inactive, Active, Charge, Attack, Dead }
    public BossState currentBossState;

    public GameObject bigSplash;
    public ScoreScript scoreScript;
    public Animator anim;

    public int maxLife;
    public int life;
    public int damage = 1;
    public int scoreValue = 500;
    public int random;
    public float chargeCounter;
    public float appearSpeed;
    public float activeSpeed;
    public float attackSpeed;
    public bool active;

    public Transform player;
    public Vector2 playerPos;
    public Vector2 direction;

    void Start ()
    {
        life = maxLife;
        Inactive();
	}

	void Update ()
    {
        switch (currentBossState)
        {
            case BossState.Inactive:
                Inactive();
                break;
            case BossState.Active:
                Active();
                break;
            case BossState.Charge:
                Charge();
                break;
            case BossState.Attack:
                Attack();
                break;
            case BossState.Dead:
                Dead();
                break;
            default:
                break;
        }
    }

    public void RecieveDamage(int damage)
    {
        Debug.Log("boss damaged?");
        life -= damage;
        if (life == 0)
        {
            //Instantiate(bigSplash, new Vector3(this.transform.position.x, this.transform.position.y, 0), new Quaternion(0, 0, 0, 0));
            scoreScript.UpdateScore(scoreValue);
            Dead();
        }
    }

    #region Updates
    void Inactive()
    {
        //anim.SetTrigger("Idle");
        chargeCounter = 2;
        if (active)
        {
            //this.transform.Translate(new Vector3(this.transform.localPosition.x, 0, 0) * appearSpeed * Time.deltaTime);
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - Time.deltaTime * appearSpeed, 0);
            if (this.transform.localPosition.y <= 0)
            {
                ActiveState();
            }
        }
        else
        {
            this.transform.position = new Vector3(7, 7, 0);
        }
    }

    void Active()
    {
        //anim.SetTrigger("Idle");
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + Time.deltaTime * activeSpeed, 0);
        if (this.transform.localPosition.y <= -1) activeSpeed *= -1;
        if (this.transform.localPosition.y >= 3) activeSpeed *= -1;

        random = Random.Range(1, 6000);
        Debug.Log("randomizing");
        if (random <= 35)
        {
            Debug.Log("strike");
            ChargeState();
        }
        //if (this.transform.localPosition.y >= -1)
        //{
        //    this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + Time.deltaTime * activeSpeed, 0);
        //}
        //if (this.transform.localPosition.y >= 3)
        //{
        //    this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - Time.deltaTime * activeSpeed, 0);
        //}
    }

    void Charge()
    {
        //anim.SetTrigger("Charge");
        chargeCounter -= Time.deltaTime;
        playerPos = player.transform.position;
        direction = (new Vector2(playerPos.x, playerPos.y) - new Vector2(this.transform.position.x, this.transform.position.y)).normalized;
        if (chargeCounter <= 0)
        {
            AttackState();
        }
    }

    void Attack()
    {
        //anim.SetTrigger("Attack");
        this.transform.Translate(new Vector3(direction.x, direction.y, 0) * attackSpeed * Time.deltaTime);
        if (this.transform.localPosition.x <= -12)
        {
            this.transform.position = new Vector3(7, 7, 0);
            InactiveState();
        }
    }

    void Dead()
    {
        active = false;
        life = maxLife;
        InactiveState();
    }
    #endregion

    #region States
    public void InactiveState()
    {
        anim.SetTrigger("Idle");
        currentBossState = BossState.Inactive;
    }

    public void ActiveState()
    {
        currentBossState = BossState.Active;
    }

    public void ChargeState()
    {
        anim.SetTrigger("Charge");
        currentBossState = BossState.Charge;
    }

    public void AttackState()
    {
        anim.SetTrigger("Attack");
        currentBossState = BossState.Attack;
    }

    public void DeadState()
    {
        currentBossState = BossState.Dead;
    }
    #endregion
}
