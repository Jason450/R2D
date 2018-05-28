using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    [Header("Stats")]
    //public bool playingLvl;
    public float speed;
    [Header("Physics")]
    public Transform cloud;
    private Vector2 cloudPos;

	void Start ()
    {
        cloudPos = new Vector2(cloud.position.x, cloud.position.y);
	}
	
	void Update ()
    {
        //if(playingLvl)
        //{
        //}
        cloudPos.x -= speed * Time.deltaTime;
        cloud.position = new Vector3(cloudPos.x, cloudPos.y, 0);

        if (cloudPos.x <= -12)
        {
            cloudPos.x = 12;
            //speed = Random.Range(5, 10);
        }
    }

    //public void PlayingLevel(bool isPlaying)
    //{
    //    playingLvl = isPlaying;
    //}
}
