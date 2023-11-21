using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Singleplayer()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("LevelPicker");
    }
    public void Multiplayer()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("Demo");
    }
    public void Settings()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("Graphics");
    }
    public void Credits()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("");
    }
    // Update is called once per frame
    public void ExitGame()
    {
        // Quit the application when the Exit button is pressed.
        Application.Quit();
    }
}
