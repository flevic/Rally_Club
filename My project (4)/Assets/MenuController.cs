using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TMP_Dropdown fpsDropdown;
    private int selectedFPS;
    private string fpsPlayerPrefsKey = "SelectedFPS";
    public Toggle fullscreenToggle;

    public Button veryLowQButton;
    public Button lowQButton;
    public Button medQButton;
    public Button highQButton;
    public Button veryHighQButton;

    private void Start()
    {
        // Initialize the toggle state based on the current fullscreen mode.
        fullscreenToggle.isOn = Screen.fullScreen;
        // Subscribe to the Dropdown's OnValueChanged event
        fpsDropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(fpsDropdown);
        });

        // Set the default value (Off in this case)
        // Load the selected FPS value from PlayerPrefs
        selectedFPS = PlayerPrefs.GetInt(fpsPlayerPrefsKey, 2);

        // Set the dropdown value based on the loaded value
        fpsDropdown.SetValueWithoutNotify(selectedFPS);
        ApplyFPSLimit();

        HighlightQualityButton(QualitySettings.GetQualityLevel());
    }
    public void VeryLowQ()
    {
        QualitySettings.SetQualityLevel(0, true); // Fastest Quality
        HighlightQualityButton(0);
    }

    public void LowQ()
    {
        QualitySettings.SetQualityLevel(1, true); // Simple Graphics
        HighlightQualityButton(1);
    }

    public void MedQ()
    {
        QualitySettings.SetQualityLevel(2, true); // Good Graphics
        HighlightQualityButton(2);
    }

    public void HighQ()
    {
        QualitySettings.SetQualityLevel(3, true); // Beautiful Graphics
        HighlightQualityButton(3);
    }

    public void VeryHighQ()
    {
        QualitySettings.SetQualityLevel(4, true); // Fantastic Graphics
        HighlightQualityButton(4);
    }

    // Method to highlight the quality button based on the selected quality level
    private void HighlightQualityButton(int qualityLevel)
    {
        veryLowQButton.interactable = qualityLevel != 0;
        lowQButton.interactable = qualityLevel != 1;
        medQButton.interactable = qualityLevel != 2;
        highQButton.interactable = qualityLevel != 3;
        veryHighQButton.interactable = qualityLevel != 4;
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

    void DropdownValueChanged(TMP_Dropdown change)
    {
        // Update the selectedFPS based on the dropdown selection
        selectedFPS = change.value;

        // Save the selected FPS value to PlayerPrefs
        PlayerPrefs.SetInt(fpsPlayerPrefsKey, selectedFPS);
        PlayerPrefs.Save();

        // Apply the FPS limit
        ApplyFPSLimit();
    }

    void ApplyFPSLimit()
    {
        // Check the selectedFPS value and set the frame rate accordingly
        switch (selectedFPS)
        {
            case 0: // Off
                Application.targetFrameRate = -1; // Unlimited frame rate
                break;

            case 1: // 30 FPS
                Application.targetFrameRate = 30;
                break;

            case 2: // 60 FPS
                Application.targetFrameRate = 60;
                break;

            case 3: // 120 FPS
                Application.targetFrameRate = 120;
                break;
            case 4: // 120 FPS
                Application.targetFrameRate = 240;
                break;
            default:
                break;
        }
    }

}
