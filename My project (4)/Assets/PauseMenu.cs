using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Continue()
    {
      
        panel.SetActive(!panel.activeSelf);
        print(panel.activeSelf);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void LevelPick()
    {
        SceneManager.LoadScene("LevelPicker");
    }
    public void MainMenu()
    {
        SaveSystem.SaveGame(SaveManager.instance.data.currentSaveSlot);
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}
