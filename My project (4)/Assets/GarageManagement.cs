using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GarageManagement : MonoBehaviour
{
    public int GarageIndex;
    public GameObject[] cars;
    public bool unlocked;
    public Button confirm;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 dropPosition = new Vector3(0f, 5f, 0f);
        GarageIndex = SaveManager.instance.data.currentCarIndex;
        cars[GarageIndex].transform.position = dropPosition;
    }

    public void Left()
    {
        Vector3 dropPosition = new Vector3(0f, 5f, 0f);
        Vector3 awayPosition = new Vector3(45f, 5f, 0f);
        if (GarageIndex  > 0) 
        {
            cars[GarageIndex].transform.position = awayPosition;
            GarageIndex--;
        cars[GarageIndex].transform.position = dropPosition;
    }
    }

    public void Right()
    {
        Vector3 dropPosition = new Vector3(0f, 5f, 0f);
        Vector3 awayPosition = new Vector3(45f, 5f, 0f);
        if (GarageIndex < cars.Length-1)
        {
        cars[GarageIndex].transform.position = awayPosition;
        GarageIndex++;
        cars[GarageIndex].transform.position = dropPosition;
    }
        

    }

    public void Confirm()
    {
        SaveManager.instance.data.currentCarIndex = GarageIndex;
        SaveSystem.SaveGame(SaveManager.instance.data.currentSaveSlot);
        SceneManager.LoadScene("LevelPicker");
    }

    // Update is called once per frame
    void Update()
    {
        unlocked = SaveManager.instance.data.carsUnlocked.ElementAt(GarageIndex).Value;
        print(unlocked);
        if (unlocked)
        {
            confirm.interactable = true;

        }
        else
        {
            confirm.interactable = false;
        }
        
        //print(GarageIndex);
    }
}
