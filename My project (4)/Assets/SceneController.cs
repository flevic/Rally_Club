using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    // Start is called before the first frame update
    public void Singleplayer()
    {
        //Loops through all the buttons and if there is a save with their index their text gets set to the index, else text is set to "No Save".
        //activates/deactivates the buttons based on whether they found their slot
        for (int i = 0; i < buttons.Length; i++)
        {
            if (SaveSystem.LoadGameIfExists(i, out GameData saveGame))
            {
                buttons[i].GetComponentInChildren<TMP_Text>().text = i.ToString();
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].GetComponentInChildren<TMP_Text>().text = "No Save";
                buttons[i].interactable = false;
            }
        }

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
        SceneManager.LoadScene("Settings");
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
