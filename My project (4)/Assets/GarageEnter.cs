using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GarageEnter : MonoBehaviour
{
    public TMP_Text guide;
    // Start is called before the first frame update
    void Start()
    {
        guide.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Entered");
            guide.enabled = true;


        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E)) 
            {
                SceneManager.LoadScene("Garage");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Exited");
            guide.enabled = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
