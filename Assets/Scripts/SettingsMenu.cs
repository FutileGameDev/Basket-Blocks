using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start() //this resolutions chunk of code is needed for unity to clear our list of resolution options and replace it with hardware specific resolution options.
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) //this line checks if the resolution i in the index is our hardware's current resolution by comparing the width and height
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex; //declares current hardware resolution setting as the default game resolution
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex) //sets the game resolution to the current hardware resolution
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume) //this function adjusts the volume
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality (int qualityIndex) //this function adjusts the graphics quality
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullScreen) //this function toggles fullscreen on/off
    {
        Screen.fullScreen = isFullScreen;
    }
}
