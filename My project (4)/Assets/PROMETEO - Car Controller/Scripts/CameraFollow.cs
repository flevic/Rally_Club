using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // The GameObject to follow
    public float rotationSpeed = 5f; // Speed at which the camera rotates to follow the target
    public float delay = 0.5f; // Delay in seconds

    private void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not assigned to the camera controller.");
            return;
        }

        // Calculate the desired rotation based on the target's rotation
        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles.x, target.eulerAngles.y, transform.eulerAngles.z);

        // Use Lerp to smoothly interpolate between current and target rotations
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Apply a slight delay to the camera rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, delay * Time.deltaTime);
    }
}
    //public Transform carTransform;
    //[Range(1, 10)]
    //public float followSpeed = 2;
    //[Range(1, 10)]
    //public float lookSpeed = 5;
    //Vector3 initialCameraPosition;
    //Vector3 initialCarPosition;
    //Vector3 absoluteInitCameraPosition;

//void Start(){
//	initialCameraPosition = gameObject.transform.position;
//	initialCarPosition = carTransform.position;
//	absoluteInitCameraPosition = initialCameraPosition - initialCarPosition;
//}

//void FixedUpdate()
//{
//	//Look at car
//	Vector3 _lookDirection = (new Vector3(carTransform.position.x, carTransform.position.y, carTransform.position.z)) - transform.position;
//	Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
//	transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);

//	//Move to car
//	Vector3 _targetPos = absoluteInitCameraPosition + carTransform.transform.position;
//	transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);

//}


