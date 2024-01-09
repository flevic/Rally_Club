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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MenuScene()
    {
        PlayerPrefs.SetString("levelAt", level);
        SceneManager.LoadScene("LevelPicker");
    }
}
