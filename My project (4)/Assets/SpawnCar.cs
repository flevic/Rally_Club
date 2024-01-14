using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject[] cars;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cars[SaveManager.instance.data.currentCarIndex],transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
