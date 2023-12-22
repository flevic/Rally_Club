using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Rendering.LookDev;
using System;

[Serializable]
public class CarCamera
{
    public bool lerp;
    public float fov;
    public float camDistance;
    public float camHeight;
    public float rotationOffset;
    public float clippingDistance;
}

public class CameraSwitcher : MonoBehaviour
{
    public Text textObject;
    private Camera camera;
    public GameObject cameraPrefab;
    public CarCamera[] cameraPresets;
    private int currentCameraIndex = 0;
    private string playerPrefsKey = "ActiveCameraIndex";
    public GameObject panel; // Reference to your panel GameObject
    

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        camera = Instantiate(cameraPrefab).GetComponent<Camera>();
        camera.GetComponent<CameraFollow>().Init(GetComponentInParent<PrometeoCarController>().gameObject);
        SwitchCamera(PlayerPrefs.GetInt("ActiveCameraIndex", 0));
    }

    void Update()
    {
        // Check if the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the visibility of the panel
            panel.SetActive(!panel.activeSelf);
            
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;

            print(panel.activeSelf);
        }

        // Check for the "v" key press to switch cameras
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Switch to the next camera
            int newIndex = currentCameraIndex + 1;
            if(newIndex >= cameraPresets.Length) { newIndex = 0; }

            SwitchCamera(newIndex);
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
        camera.fieldOfView = cameraPresets[newIndex].fov;

        var camScript = camera.GetComponent<CameraFollow>();

        camScript.lerp = cameraPresets[newIndex].lerp;
        camScript.camDistance = cameraPresets[newIndex].camDistance;
        camScript.camHeight = cameraPresets[newIndex].camHeight;
        camScript.rotationOffset = cameraPresets[newIndex].rotationOffset;
        camera.nearClipPlane = cameraPresets[newIndex].clippingDistance;

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
