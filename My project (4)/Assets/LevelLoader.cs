using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public string ToUnlock;
    public GameObject childObject;

    public void Start()
    {
        print(SaveManager.instance.data.levelsDone[ToUnlock]);
        childObject = transform.GetChild(0).gameObject;
        if (SaveManager.instance.data.levelsDone[ToUnlock] == true)
        {
            print("Activate " + ToUnlock);
            childObject.SetActive(true);



        }

    }
    public void Update()
    {





    }

}
