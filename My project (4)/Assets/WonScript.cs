using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WonScript : MonoBehaviour
{
    public string level;
    // Start is called before the first frame update
    void Start()
    {
        print(SaveManager.instance.data.currentSaveSlot);

    }
    public void MenuScene()
    {
        SaveManager.instance.data.levelsDone[level] = true;
        
        SaveSystem.SaveGame(SaveManager.instance.data.currentSaveSlot);
        SceneManager.LoadScene("LevelPicker");
    }
    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}
