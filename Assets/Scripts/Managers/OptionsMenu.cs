using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    //public int quality;
    public AudioMixer masterMixer;

    void Start ()
    {
        //quality = QualitySettings.GetQualityLevel();
	}
	
	void Update ()
    {
		
	}


    public void Resolution(int res)
    {
        if(res == 1)
        {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
            Debug.Log("1280x720");
        }
        if(res == 2)
        {
            Screen.SetResolution(1600, 1200, Screen.fullScreen);
            Debug.Log("1600x1200");
        }
        if(res == 3)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
            Debug.Log("1920x1080");
        }
    }

    public void Quality(int qua)
    {
        QualitySettings.SetQualityLevel(qua);
        Debug.Log(QualitySettings.GetQualityLevel());
    }

    public void SetMasterVolume(Slider soundLevel)
    {
        masterMixer.SetFloat("masterVol", soundLevel.value);
    }

    public void SetMusicVolume(Slider soundLevel)
    {
        masterMixer.SetFloat("musicVol", soundLevel.value);
    }

    public void SetSFXVolume(Slider soundLevel)
    {
        masterMixer.SetFloat("SFXVol", soundLevel.value);
    }

    /*public void SetMasterVolume(float soundLevel)
    {
        masterMixer.SetFloat("masterVol", soundLevel);
    }

    public void SetMusicVolume(float soundLevel)
    {
        masterMixer.SetFloat("musicVol", soundLevel);
    }
    public void SetSFXVolume(float soundLevel)
    {
        masterMixer.SetFloat("SFXVol", soundLevel);
    }*/
}
