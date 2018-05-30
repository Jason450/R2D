using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public Transform shot;
    public PlayerScript player;
    public Vector2 mousePos;
    public Vector2 direction;
    public float speed;

	void Start ()
    {
        shot = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        direction = (new Vector2(mousePos.x, mousePos.y) - new Vector2(this.transform.position.x, this.transform.position.y)).normalized;
    }
	
	void Update ()
    {
        this.transform.Translate(new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime);
    }
}
