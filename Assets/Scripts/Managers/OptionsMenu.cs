using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public int quality;

    void Start ()
    {
        quality = QualitySettings.GetQualityLevel();
	}
	
	void Update ()
    {
		
	}


    public void Resolution(int res)
    {
        if(res == 1)
        {
            Debug.Log("aaa");
            Screen.SetResolution(1280, 720, Screen.fullScreen);
            Debug.Log(quality);

        }
        if(res == 2)
        {
            Debug.Log("aaa2");
            Screen.SetResolution(1600, 1200, Screen.fullScreen);
        }
        if(res == 3)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        }
    }

    public void Quality(int qua)
    {
        QualitySettings.SetQualityLevel(qua);
    }


}
