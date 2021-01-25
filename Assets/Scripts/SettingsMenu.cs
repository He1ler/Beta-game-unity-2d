using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer musicMixer;
    public Dropdown resolutionDropdown;
    //public Dropdown GrafhicDropdown;
    // public Toggle setFullscreen;
    Resolution[] resolutions;
    void Start()
    {
        //setFullscreen.isOn = Screen.fullScreen;
        //GrafhicDropdown.value = QualitySettings.GetQualityLevel();
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        int currentresolution = 0;
        List<string> nameofresolutions = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string nameofresolution = resolutions[i].width + " X " + resolutions[i].height;
            nameofresolutions.Add(nameofresolution);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentresolution = i;
            }
        }
        resolutionDropdown.AddOptions(nameofresolutions);
        resolutionDropdown.value = currentresolution;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetAudio_Volume(float Audio_Volume)
    {
        audioMixer.SetFloat("Audio", Audio_Volume);
    }
    public void SetMusic_Volume(float Music_Volume)
    {
        musicMixer.SetFloat("Music", Music_Volume);
    }
    public void SetGraphic(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void Setbrightness(float brightness)
    {
        Screen.brightness = brightness;
    }
    public void SetResolution (int resolutionindex)
    {
        Resolution resolution = resolutions[resolutionindex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
