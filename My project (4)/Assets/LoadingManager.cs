using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    public void Start()
    {
        print(SaveManager.instance.data.MouseSensitivity);
        SaveManager.instance.data.MouseSensitivity = 5f;
        print(SaveManager.instance.data.MouseSensitivity);
    }
}
