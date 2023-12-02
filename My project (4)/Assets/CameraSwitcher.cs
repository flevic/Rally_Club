using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraSwitcher : MonoBehaviour
{
    public Text textObject;
    public Camera[] cameras;
    private int currentCameraIndex = 0;
    private string playerPrefsKey = "ActiveCameraIndex";

    void Start()
    {
        // Ensure at least one camera is active
        if (cameras.Length > 0)
        {
            // Load the last active camera index from PlayerPrefs
            if (PlayerPrefs.HasKey(playerPrefsKey))
            {
                currentCameraIndex = PlayerPrefs.GetInt(playerPrefsKey);
            }

            // Switch to the last active camera
            SwitchCamera(currentCameraIndex);
        }
        else
        {
            Debug.LogError("No cameras attached to the object!");
        }
    }

    void Update()
    {
        // Check for the "v" key press to switch cameras
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Switch to the next camera
            SwitchCamera((currentCameraIndex + 1) % cameras.Length);
        }

        // Check for the "i" key press to toggle text visibility
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Toggle the visibility of the textObject
            if (textObject != null)
            {
                textObject.enabled = !textObject.enabled;
            }
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

        // Save the active camera index to PlayerPrefs
        PlayerPrefs.SetInt(playerPrefsKey, currentCameraIndex);
        PlayerPrefs.Save();
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CameraSwitcher : MonoBehaviour
//{
//    public Text textObject;
//    public Camera[] cameras;
//    private int currentCameraIndex = 0;

//    void Start()
//    {
//        // Ensure at least one camera is active
//        if (cameras.Length > 0)
//        {
//            SwitchCamera(currentCameraIndex);
//        }
//        else
//        {
//            Debug.LogError("No cameras attached to the object!");
//        }
//    }

//    void Update()
//    {
//        // Check for the "v" key press
//        if (Input.GetKeyDown(KeyCode.V))
//        {
//            // Switch to the next camera
//            SwitchCamera((currentCameraIndex + 1) % cameras.Length);
//        }
//        if (Input.GetKeyDown(KeyCode.I))
//        {
//            // Toggle the visibility of the textObject
//            if (textObject != null)
//            {
//                textObject.enabled = !textObject.enabled;
//            }
//        }
//    }

//    void SwitchCamera(int newIndex)
//    {
//        // Disable the current camera
//        cameras[currentCameraIndex].enabled = false;

//        // Enable the new camera
//        cameras[newIndex].enabled = true;

//        // Update the current camera index
//        currentCameraIndex = newIndex;
//    }
//}
