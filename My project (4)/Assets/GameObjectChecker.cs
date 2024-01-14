using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor;


public class GameObjectChecker : MonoBehaviour
{
   
    public GameObject[] gameObjects;

    public bool isntRunning = true;
    public bool Finalised = false;
    private float startTime;
    private float elapsedTime = 0.0f;
    public TMP_Text textMesh;
    public TMP_Text WontextMesh;
    public TMP_Text LosttextMesh;
    public GameObject panelWin;
    public GameObject panelLost;
    public float TargetTime;
    public bool Finished = false;
    public GameObject panelPause;
    public bool Timed;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Check if the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the visibility of the panel
            panelPause.SetActive(!panelPause.activeSelf);

            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;

            
        }
        if (Timed)
        {
            if (AllGameObjectsExist() == false)
            {
                // Do something when none of the game objects exist
                if (isntRunning)
                {
                    startTime = Time.time;
                    isntRunning = false;
                }
                if (!AllGameObjectsNotExist())
                {
                    textMesh.text = "Time: " + FormatTimeSpan(TimeSpan.FromSeconds(Time.time - startTime));
                }
            }
            // Check if EVERY game object from the list doesn't exist
            if (AllGameObjectsNotExist())
            {
                if (!Finalised)
                {
                    elapsedTime += (Time.time - startTime);
                    textMesh.gameObject.SetActive(false);
                    Finalised = true;
                }
                print(elapsedTime);
                if (elapsedTime <= TargetTime && Finished == false)
                {

                    // Toggle the visibility of the panel
                    panelWin.SetActive(!panelWin.activeSelf);
                    WontextMesh.text = "Final Time: " + FormatTimeSpan(TimeSpan.FromSeconds(Time.time - startTime));
                    Cursor.visible = !Cursor.visible;
                    Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;

                    print(panelWin.activeSelf);   // Do something when none of the game objects exist
                    Finished = true;
                }

                if (elapsedTime >= TargetTime && Finished == false)
                {

                    // Toggle the visibility of the panel
                    panelLost.SetActive(!panelLost.activeSelf);
                    LosttextMesh.text = "Final Time: " + FormatTimeSpan(TimeSpan.FromSeconds(Time.time - startTime));
                    Cursor.visible = !Cursor.visible;
                    Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;

                    print(panelLost.activeSelf);   // Do something when none of the game objects exist
                    Finished = true;
                }
            }

        }
    }
    string FormatTimeSpan(TimeSpan timeSpan)
    {
        return string.Format("{0:mm\\:ss\\:fff}", timeSpan);
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
