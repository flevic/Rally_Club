using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectChecker : MonoBehaviour
{
    public GameObject[] gameObjects;
    public string Scene;

    void Update()
    {
        // Check if EVERY game object from the list doesn't exist
        if (AllGameObjectsNotExist())
        {
            // Do something when none of the game objects exist
            SceneManager.LoadScene(Scene);
        }
    }

    bool AllGameObjectsNotExist()
    {
        // Iterate through the list of game objects
        foreach (GameObject obj in gameObjects)
        {
            // If any game object exists, return false
            if (obj != null)
            {
                return false;
            }
        }

        // If none of the game objects exist, return true
        return true;
    }
}
