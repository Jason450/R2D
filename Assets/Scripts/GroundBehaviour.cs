using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehaviour : MonoBehaviour
{
    public Transform ground;
    Vector3 groundPos;

	void Start ()
    {
        ground = GetComponent<Transform>();
        groundPos = ground.transform.position;
	}
	
	void Update ()
    {
        groundPos.x -= Time.deltaTime * 5;
        ground.transform.position = new Vector3(groundPos.x, groundPos.y, groundPos.z);

        if(groundPos.x <= -19) groundPos.x = 19;
	}
}
