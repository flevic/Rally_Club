using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        if (!IsOwner) { return; }
        camera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
