using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public string levelAt = "LevelPicker";
    public string ToUnlock;
    public GameObject childObject;
    public void Start()
    {
        childObject = transform.GetChild(0).gameObject;
        levelAt = PlayerPrefs.GetString("levelAt", "LevelPicker");
        print(levelAt);
    }
    public void Update()
    {
        if (levelAt == ToUnlock)
        {
            childObject.SetActive(true);
        }


    }

}