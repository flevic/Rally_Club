using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        // Ensure at least one camera is active
        if (cameras.Length > 0)
        {
            SwitchCamera(currentCameraIndex);
        }
        else
        {
            Debug.LogError("No cameras attached to the object!");
        }
    }

    void Update()
    {
        // Check for the "v" key press
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Switch to the next camera
            SwitchCamera((currentCameraIndex + 1) % cameras.Length);
        }
    }

    void SwitchCamera(int newIndex)
    {
        // Disable the current camera
        cameras[currentCameraIndex].enabled = false;

        // Enable the new camera
        cameras[newIndex].enabled = true;

        // Update the current camera index
        currentCameraIndex = newIndex;
    }
}
