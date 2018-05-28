using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform trans;
    public Vector3 position;
    public float scrollSpeed;

    void Start ()
    {
        trans = this.gameObject.GetComponent<Transform>();
        position = trans.localPosition;
    }
	
	void Update ()
    {
        position.x -= scrollSpeed * Time.deltaTime;
        trans.localPosition = position;

        if (position.x <= -13)
        {
            position.x += 24;
            position.y = Random.Range(-7, -4.5f);
        }
    }
}
