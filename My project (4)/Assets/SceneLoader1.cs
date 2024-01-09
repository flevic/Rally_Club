using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader1 : MonoBehaviour
{
    // Name of the scene to load.
    public string Scene;
    // This method gets called when something enters the trigger area.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding GameObject has a "Player" tag.
        if (other.CompareTag("Player"))
        {
            Debug.Log("Load");
            // Load the specified scene.
            SceneManager.LoadScene(Scene);
        } 
    }
}
