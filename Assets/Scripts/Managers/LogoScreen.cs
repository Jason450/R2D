using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogoScreen : MonoBehaviour
{
    public float counter;
    public Image image;

	void Start ()
    {
        counter = 3;
        image.color = new Vector4(image.color.r, image.color.g, image.color.b, image.color.a);
    }

    void Update ()
    {
        counter -= Time.deltaTime;

        if (counter <= 0 && image.color.a >= 1)
        {
            counter = 0;
            SceneManager.LoadScene(1);
        }
    }
}
