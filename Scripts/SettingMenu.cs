using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
  
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }



}
