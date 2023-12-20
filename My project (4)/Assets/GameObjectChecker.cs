using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
using TMPro;


public class GameObjectChecker : MonoBehaviour
{
    public GameObject[] gameObjects;
    public string Scene;
    public bool isRunning = false;
    private float startTime;
    private float elapsedTime = 0.0f;
    public TMP_Text textMesh;
    public GameObject panelWin;
    public float TargetTime;
    void FixedUpdate()
    {
        if (AllGameObjectsExist() == false)
        {
            // Do something when none of the game objects exist
            if (AllGameObjectsNotExist() == false)
            {
                startTime++;
                isRunning = true;
            }
            }
        // Check if EVERY game object from the list doesn't exist
        if (AllGameObjectsNotExist())
        {
            if (isRunning)
            {
                elapsedTime = startTime;
                isRunning = false;
            }
            print(elapsedTime);
            if (elapsedTime <= TargetTime)
            {

                // Toggle the visibility of the panel
                panelWin.SetActive(!panelWin.activeSelf);

                Cursor.visible = !Cursor.visible;
                Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;

                print(panelWin.activeSelf);   // Do something when none of the game objects exist
                SceneManager.LoadScene(Scene);
            }
        }
        textMesh.text = "Time: " + startTime;
    }
    bool AllGameObjectsExist()
    {
        // Iterate through the list of game objects
        foreach (GameObject obj in gameObjects)
        {
            // If any game object exists, return false
            if (obj == null)
            {
                return false;
            }
        }

        // If none of the game objects exist, return true
        return true;
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
