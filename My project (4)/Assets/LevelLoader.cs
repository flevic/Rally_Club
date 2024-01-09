using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public string name;
    public string reset;
    public string levelAt = "LevelPicker";
    public bool active = false;
    public string ToUnlock;
    public GameObject childObject;
    public string activateMe;
    public void Start()
    {
        childObject = transform.GetChild(0).gameObject;
        levelAt = PlayerPrefs.GetString("levelAt", "LevelPicker");
        print(levelAt);
        reset = PlayerPrefs.GetString("reset", "false");
        
        
        name = childObject.GetComponent<SceneLoader1>().Scene;
        
        
    }
    public void Update()
    {
        reset = PlayerPrefs.GetString("reset", "false");
        activateMe = PlayerPrefs.GetString(name, "false");
        
       

        if (reset == "true")
        {
            print(reset);
            childObject.SetActive(false);
            
            PlayerPrefs.SetString(name, "false");


            
            
        }
        reset = PlayerPrefs.GetString("reset", "false");
        activateMe = PlayerPrefs.GetString(name, "false");
        //print(activateMe);
        //print("This should be: "+active);
        reset = PlayerPrefs.GetString("reset", "false");
        
        if (levelAt == ToUnlock|| activateMe == "true")
        {
            
            childObject.SetActive(true);
            PlayerPrefs.SetString(name, "true");
            

        }

        
    }
    
}
