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
    public void MenuScene()
    {
    PlayerPrefs.SetString("levelAt", level);
    SceneManager.LoadScene("LevelPicker");
    }

}
