using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTime : MonoBehaviour
{
    float time;
    float unscaledTime;
	// Use this for initialization
	void Start ()
    {
        time = 0;
        unscaledTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        unscaledTime += Time.unscaledDeltaTime / 2;
        Debug.Log("Time " + time);
        Debug.Log("Unscaled " + unscaledTime);

        if (Input.GetKeyDown(KeyCode.P)) Time.timeScale = 0;
    }
}
