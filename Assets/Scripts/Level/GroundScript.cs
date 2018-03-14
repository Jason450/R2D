using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public SpriteRenderer spriteRend;
    public Vector2 offSet;
    public float scrollSpeed;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        scrollSpeed += 0.1f * Time.deltaTime;

        if (offSet.x >= 1) offSet.x = 0;

        offSet.x += scrollSpeed * Time.deltaTime;
        spriteRend.material.mainTextureOffset = offSet;

        if (scrollSpeed >= 15) scrollSpeed = 15;
	}
}
