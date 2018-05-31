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

	void Start ()
    {
        shot = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        //mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //clickPos = cam.ScreenToViewportPoint(Input.mousePosition);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (new Vector2(mousePos.x, mousePos.y) - new Vector2(this.transform.position.x, this.transform.position.y)).normalized;
        Destroy(this.gameObject, 5);
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
        //mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        //this.transform.localPosition = mousePos;
        //Debug.Log(Input.mousePosition);
    }
}
