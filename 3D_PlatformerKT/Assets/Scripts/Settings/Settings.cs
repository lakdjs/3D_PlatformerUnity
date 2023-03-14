using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Settings : MonoBehaviour
{
    public TMPro.TMP_Dropdown ResolutionDropdown;
    public TMPro.TMP_Dropdown QualityDropdown;
    
    Resolution[] resolutions;

    void Start()
    {
        ResolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int CurResIndex = 0;
        for(int i = 0; i> resolutions.Length; i++ )
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                CurResIndex = i;
            }

        }
        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.RefreshShownValue();
        LoadSettings(CurResIndex);
    }

    public void SetFullscreen(bool ifFullscreen)
    {
        Screen.fullScreen = ifFullscreen;
    }
    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void ExitSettings()
    {
        SceneManager.LoadScene("FirstScene");
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingsPreference",QualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionSettingsPreference",ResolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenSettingsPreference", System.Convert.ToInt32(Screen.fullScreen));
    }
    public void LoadSettings(int curResInd)
    {
        if(PlayerPrefs.HasKey("QualitySettingsPreference"))
        {
            QualityDropdown.value = PlayerPrefs.GetInt("QualitySettingsPreference");
        }
        else
        {
            QualityDropdown.value = 3;
        }

        if(PlayerPrefs.HasKey("ResolutionSettingsPreference"))
        {
            ResolutionDropdown.value = PlayerPrefs.GetInt("ResolutionSettingsPreference");
        }
        else
        {
            ResolutionDropdown.value = curResInd;
        }

        if(PlayerPrefs.HasKey("FullscreenSettingsPreference"))
        {
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenSettingsPreference"));
        }
        else
        {
            Screen.fullScreen = true;
        }
    }
}
