using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public bool playingLvl;
    public SpriteRenderer spriteRend;
    public Vector2 offSet;
    public float scrollSpeed;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if(playingLvl)
        {
            scrollSpeed += 0.1f * Time.deltaTime;
            offSet.x += scrollSpeed * Time.deltaTime;
            spriteRend.material.mainTextureOffset = offSet;
        }

        if (offSet.x >= 1) offSet.x = 0;
        if (scrollSpeed >= 15) scrollSpeed = 15;
	}

    public void PlayingLevel(bool isPlaying)
    {
        playingLvl = isPlaying;
    }

    public void Reset()
    {
        scrollSpeed = 5;
    }
}
