using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform trans;
    public SpriteRenderer sprite;
    public Vector3 position;
    public float scrollSpeed;
    public bool flip;
    public bool randomAdd;
    public int random;
    public float randomAddValue;
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;
    public float xLimit;
    public float addPosValue;

    void Start ()
    {
        trans = this.gameObject.GetComponent<Transform>();
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        position = trans.localPosition;
        flip = false;
    }
	
	void Update ()
    {
        position.x -= scrollSpeed * Time.deltaTime;
        trans.localPosition = position;

        if (randomAdd)
        {
            randomAddValue = Random.Range(minX, maxX);
            addPosValue = randomAddValue;
        }

        if (position.x <= xLimit)
        {
            position.x += addPosValue;
            position.y = Random.Range(minY, maxY);

            random = Random.Range(0, 2);

            if (random == 0)
            {
                flip = false;
            }
            else
            {
                flip = true;
            }

            if (flip)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
    }
}
