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
    [Header("Bools")]
    public bool canJump;
    public bool isJumping;
    [Header("Forces")]
    public float jumpForce;

	void Start ()
    {
        life = 1;
	}
	
	void Update ()
    {
        if (life <= 0)
        {
            lvlManager.FinishLevel();
        }

        if (Input.GetKey(KeyCode.DownArrow))
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
        }
    }

    public void RecieveDamage(int damage)
    {
        life -= damage;
    }
}
