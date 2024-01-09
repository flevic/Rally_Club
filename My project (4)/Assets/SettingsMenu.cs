using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public void Graphics()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("Graphics");
    }
    public void Audio()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("Audio");
    }
    public void ResetProgress()
    {

    }
    public void Back()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("MainMenu");
    }
}
