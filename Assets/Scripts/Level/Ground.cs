using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    //public bool playingLvl;
    public Transform trans;
    public Vector3 position;
    public float scrollSpeed;
    public List<Sprite> sprites;
    public List<SpriteRenderer> randomSprite;

    void Start()
    {
        trans = this.gameObject.GetComponent<Transform>();
        position = trans.localPosition;
    }

    void Update()
    {
        //scrollSpeed += 0.1f * Time.deltaTime;
        position.x -= scrollSpeed * Time.deltaTime;
        trans.localPosition = position;

        if (position.x <= -20)
        {
            position.x += 40;
            RandomizeSprites();
        }

        //if (playingLvl)
        //{
        //    scrollSpeed += 0.1f * Time.deltaTime;
        //    offSet.x += scrollSpeed * Time.deltaTime;
        //}

        //if (offSet.x >= 1) offSet.x = 0;
        //if (scrollSpeed >= 15) scrollSpeed = 15;
    }

    //public void PlayingLevel(bool isPlaying)
    //{
    //    playingLvl = isPlaying;
    //}

    public void Reset()
    {
        scrollSpeed = 5;
    }

    void RandomizeSprites()
    {
        for (int i = 0; i < randomSprite.Count; i++)
        {
            randomSprite[i].sprite = sprites[Random.Range(0, sprites.Count)];
        }
    }
}
