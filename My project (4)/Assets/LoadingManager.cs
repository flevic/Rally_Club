using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    public GameObject[] gameObjects;

    bool AllGameObjectsNotExist()
    {
        // Iterate through the list of game objects
        foreach (GameObject obj in gameObjects)
        {
            // If any game object exists, return false
            if (obj.activeInHierarchy)
            {
                return false;
            }
        }

        // If none of the game objects exist, return true
        return true;
    }
    public void Update()
    {
        if (AllGameObjectsNotExist())
        {
            PlayerPrefs.SetString("reset", "false");
        }
    }
}
