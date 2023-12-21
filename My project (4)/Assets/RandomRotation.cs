using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public string playerTag = "Player";

    void Update()
    {
        GameObject playerObject = GameObject.FindWithTag(playerTag);

        if (playerObject != null)
        {
            // Calculate the target direction only in the x and z axes
            Vector3 targetDirection = new Vector3(playerObject.transform.position.x - transform.position.x, 0f, playerObject.transform.position.z - transform.position.z);

            // Use LookRotation to get the desired rotation only around the y-axis
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // Apply the rotation to your object
            transform.rotation = targetRotation;
        }
        else
        {
            Debug.LogWarning($"No object with tag '{playerTag}' found. Make sure the car has the correct tag.");
        }
    }
}






