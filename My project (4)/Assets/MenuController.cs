using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Toggle fullscreenToggle;
    private void Start()
    {
        // Initialize the toggle state based on the current fullscreen mode.
        fullscreenToggle.isOn = Screen.fullScreen;
    }
    public void VeryLowQ()
    {
        QualitySettings.SetQualityLevel(0, true); //Fastest Quality
    }
    public void LowQ()
    {
        QualitySettings.SetQualityLevel(1, true); //Fastest Quality
    }
    public void MedQ()
    {
        QualitySettings.SetQualityLevel(2, true); //Simple Graphics
    }
    public void HighQ()
    {
        QualitySettings.SetQualityLevel(3, true); //Fastest Quality
    }
    public void VeryHighQ()
    {
        QualitySettings.SetQualityLevel(4, true); //Fantastic Graphics
    }
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void Back()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("MainMenu");
    }

}
