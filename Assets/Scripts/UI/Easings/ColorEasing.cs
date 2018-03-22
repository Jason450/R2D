using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorEasing : MonoBehaviour
{
    public float iniValue;
    public float finalValue;
    public float deltaValue;
    public float currentTime;
    public float timeDuration;
    public float startDelay;
    public Image image;

    // Use this for initialization
    void Start()
    {
        currentTime = 0;
        deltaValue = finalValue - iniValue;
        image.color = new Vector4(image.color.r, image.color.g, image.color.b, iniValue);
    }

    // Update is called once per frame
    void Update()
    {
        if(startDelay > 0)
        {
            startDelay -= Time.deltaTime;
            return;
        }

        if(currentTime <= timeDuration)
        {
            currentTime += Time.deltaTime;

            float value = Easing.QuadEaseOut(currentTime, iniValue, deltaValue, timeDuration);

            image.color = new Vector4(image.color.r, image.color.g, image.color.b, value);

            currentTime += Time.deltaTime;

            if(currentTime >= timeDuration)
            {
                image.color = new Vector4(image.color.r, image.color.g, image.color.b, finalValue);
            }
        }
    }
}