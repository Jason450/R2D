using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Other Scripts")]
    public LevelManager lvlManager;
    [Header("Stats")]
    public int life;
    [Header("Physics")]
    public PlayerCollisions collisions;
    public Rigidbody2D rb;
    [Header("Graphics")]
    public Animator anim;
    [Header("Audio")]
    public AudioSource sound;
    [Header("Bools")]
    public bool canJump;
    public bool isJumping;
    public bool godMode;
    [Header("Forces")]
    public float jumpForce;

	void Start ()
    {
        godMode = false;
        life = 1;
        this.transform.localPosition = new Vector3(-5, -2.35f, 0);
    }

    void Update ()
    {
        //if (life <= 0)
        //{
        //    lvlManager.FinishLevel();
        //}

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.gravityScale = 4;
        }
        
        if (collisions.isGrounded)
        {
            rb.gravityScale = 2;
        }
    }

    private void FixedUpdate()
    {
        collisions.MyFixedUpdate();
        
        if (isJumping)
        {
            isJumping = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (collisions.isGrounded)
        {
            canJump = true;
            anim.SetBool("IsJumping", false);
        }
        else canJump = false;
    }

    void Jump()
    {
        isJumping = true;
        anim.SetBool("IsJumping", true);
    }

    public void JumpStart()
    {
        if (!canJump) return;

        if (collisions.isGrounded)
        {
            Jump();
            sound.Play();
        }
    }

    public void RecieveDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Reset();
            lvlManager.FinishLevel();
        }
    }

    public void Shot()
    {
        
    }

    public void Reset()
    {
        this.transform.localPosition = new Vector3(-5, -2.35f, 0);
    }

    public void GodMode()
    {
        godMode = !godMode;
        if (godMode)
        {
            Debug.Log("God Mode On");
            Physics2D.IgnoreLayerCollision(8, 10, true);
        }
        else
        {
            Debug.Log("God Mode Off");
            Physics2D.IgnoreLayerCollision(8, 10, false);
        }
    }
}
