using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//source: https://www.youtube.com/watch?v=YOaYQrN1oYQ 
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public Toggle toggleCB;
    public GameObject CB;
    void Start()
    {
        //resolution
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);//add to list

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);//added to our dropdown
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        //color blind
        if(PlayerPrefs.GetInt("ToogleBool") == 1)
        {
            toggleCB.isOn = true;
        }
        else
        {
            toggleCB.isOn = false;
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }
    public void Update()
    {
        if (toggleCB.isOn == true)
        {
            PlayerPrefs.SetInt("ToggleBool", 1);
            CB.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("ToggleBool", 0);
            CB.SetActive(false);
        }

    }
}
