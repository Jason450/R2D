using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public Transform shot;
    public PlayerScript player;
    public Vector2 mousePos;
    public Vector2 direction;
    public Vector3 clickPos;
    public float speed;
    public int damage;

	void Start ()
    {
        shot = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPos = new Vector3(mousePos.x, mousePos.y, 0);
        //shot.right = clickPos - shot.localPosition;
        direction = (new Vector2(mousePos.x, mousePos.y) - new Vector2(this.transform.position.x, this.transform.position.y)).normalized;
        Destroy(this.gameObject, 4);
    }
	
	void Update ()
    {
        this.transform.Translate(new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime);

        if (shot.localPosition.x >= 10)
        {
            Destroy(this.gameObject);
        }
        if (shot.localPosition.y >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("shot connect");
        if (collision.gameObject.tag == "Enemy01")
        {
            collision.gameObject.GetComponent<EnemyScript>().RecieveDamage(damage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy02")
        {
            collision.gameObject.GetComponent<Enemy2Script>().RecieveDamage(damage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            Debug.Log("Destroyed by ground");
            Destroy(this.gameObject);
        }
    }
}
