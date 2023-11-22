using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //    public Transform car; // The car transform

    //    public float rotationSpeed = 5f; // Speed of camera rotation
    //    public float rotationLerpFactor = 0.1f; // Lerp factor for smooth rotation

    //    void Update()
    //    {
    //        HandleRotation();
    //    }

    //    void HandleRotation()
    //    {
    //        // Get the horizontal input for rotation
    //        float horizontalInput = Input.GetAxis("Horizontal");

    //        // Calculate the desired rotation angle based on the input
    //        float targetRotation = car.eulerAngles.y + horizontalInput * rotationSpeed;

    //        // Adjust the target rotation to smoothly go to the other side when steering in the opposite direction
    //        if (horizontalInput < 0)
    //        {
    //            targetRotation = Mathf.Lerp(targetRotation, targetRotation - 180f, rotationLerpFactor);
    //        }
    //        else if (horizontalInput > 0)
    //        {
    //            targetRotation = Mathf.Lerp(targetRotation, targetRotation + 180f, rotationLerpFactor);
    //        }

    //        // Convert the target rotation to the -180 to 180 range
    //        targetRotation = Mathf.Repeat(targetRotation + 180f, 360f) - 180f;

    //        // Use Quaternion.Slerp to smoothly interpolate the rotation based on steering input
    //        Quaternion currentRotation = transform.rotation;
    //        Quaternion desiredRotation = Quaternion.Euler(0, targetRotation, 0);

    //        float slerpSpeed = 0.5f * Mathf.Abs(horizontalInput); // Adjust slerp speed based on steering input
    //        transform.rotation = Quaternion.Slerp(currentRotation, desiredRotation, Time.deltaTime * slerpSpeed);

    //        // Only affect the y rotation axis
    //        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

    //        // Calculate the desired forward direction
    //        Vector3 targetForward = (car.position - transform.position).normalized;
    //        // Smoothly interpolate the forward direction
    //        float smoothness = 0.1f; // You can adjust this value to control the slerp speed

    //        if (Mathf.Abs(horizontalInput) < 0.01f)
    //        {
    //            // If no steering input, reset the rotation to center
    //            transform.forward = Vector3.Lerp(transform.forward, targetForward, smoothness * Time.deltaTime);
    //        }
    //        else
    //        {
    //            // If steering input, adjust the forward direction based on car position
    //            transform.forward = Vector3.Slerp(transform.forward, (car.position - transform.position).normalized, Time.deltaTime * slerpSpeed);
    //        }
    //    }
    //}
    public Transform car; // The car transform

    public float rotationSpeed = 5f; // Speed of camera rotation
    public float rotationLerpFactor = 0.1f; // Lerp factor for smooth rotation

    void Update()
    {
        HandleRotation();
    }

    void HandleRotation()
    {
        // Get the horizontal input for rotation
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the desired rotation angle based on the input
        float targetRotation = car.eulerAngles.y + horizontalInput * rotationSpeed;

        // Convert the target rotation to the -180 to 180 range
        targetRotation = Mathf.Repeat(targetRotation + 180f, 360f) - 180f;

        // Use Quaternion.Slerp to smoothly interpolate the rotation based on steering input
        Quaternion currentRotation = transform.rotation;
        Quaternion desiredRotation = Quaternion.Euler(0, targetRotation, 0);

        float slerpSpeed = 0.5f * Mathf.Abs(horizontalInput); // Adjust slerp speed based on steering input
        transform.rotation = Quaternion.Slerp(currentRotation, desiredRotation, Time.deltaTime * slerpSpeed);

        // Only affect the y rotation axis
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        // Calculate the desired forward direction
        Vector3 targetForward = (car.position - transform.position).normalized;
        // Smoothly interpolate the forward direction
        float smoothness = 0.99f; // You can adjust this value to control the slerp speed

        if (Mathf.Abs(horizontalInput) < 0.01f)
        {
            // If no steering input, reset the rotation to center
            transform.forward = Vector3.Lerp(transform.forward, targetForward, smoothness * Time.deltaTime);
        }
        else
        {
            // If steering input, adjust the forward direction based on car position
            transform.forward = Vector3.Slerp(transform.forward, (car.position - transform.position).normalized, Time.deltaTime * slerpSpeed);
        }
    }
}
//    public Transform car; // The car transform

//    public float rotationSpeed = 5f; // Speed of camera rotation
//    public float rotationLerpFactor = 0.1f; // Lerp factor for smooth rotation

//    void Update()
//    {
//        HandleRotation();
//    }

//    void HandleRotation()
//    {
//        // Get the horizontal input for rotation
//        float horizontalInput = Input.GetAxis("Horizontal");

//        // Calculate the desired rotation angle based on the input
//        float targetRotation = car.eulerAngles.y + horizontalInput * rotationSpeed;

//        // Convert the target rotation to the -180 to 180 range
//        targetRotation = Mathf.Repeat(targetRotation + 180f, 360f) - 180f;

//        // Use Quaternion.Slerp to smoothly interpolate the rotation based on steering input
//        Quaternion currentRotation = transform.rotation;
//        Quaternion desiredRotation = Quaternion.Euler(0, targetRotation, 0);

//        float slerpSpeed = 0.5f * Mathf.Abs(horizontalInput); // Adjust slerp speed based on steering input
//        transform.rotation = Quaternion.Slerp(currentRotation, desiredRotation, Time.deltaTime * slerpSpeed);
//        // Calculate the desired forward direction
//        Vector3 targetForward = (car.position - transform.position).normalized;
//        // Smoothly interpolate the forward direction
//        float smoothness = 0.1f; // You can adjust this value to control the slerp speed

//        if (Mathf.Abs(horizontalInput) < 0.01f)
//        {
//            // If no steering input, reset the rotation to center
//            transform.forward = Vector3.Lerp(transform.forward, targetForward, smoothness * Time.deltaTime);
//        }
//        else
//        {
//            // If steering input, adjust the forward direction based on car position
//            transform.forward = Vector3.Slerp(transform.forward, (car.position - transform.position).normalized, Time.deltaTime * slerpSpeed);
//        }
//    }
//}
//    public Transform car; // The car transform

//    public float rotationSpeed = 5f; // Speed of camera rotation
//    public float rotationLerpFactor = 0.1f; // Lerp factor for smooth rotation

//    void Update()
//    {
//        HandleRotation();
//    }

//    void HandleRotation()
//    {
//        // Get the horizontal input for rotation
//        float horizontalInput = Input.GetAxis("Horizontal");

//        // Calculate the desired rotation angle based on the input
//        float targetRotation = car.eulerAngles.y + horizontalInput * rotationSpeed;

//        // Convert the target rotation to the -180 to 180 range
//        targetRotation = Mathf.Repeat(targetRotation + 180f, 360f) - 180f;

//        // Use Quaternion.Slerp to smoothly interpolate the rotation based on steering input
//        Quaternion currentRotation = transform.rotation;
//        Quaternion desiredRotation = Quaternion.Euler(0, targetRotation, 0);

//        float slerpSpeed = 0.5f * Mathf.Abs(horizontalInput); // Adjust slerp speed based on steering input
//        transform.rotation = Quaternion.Slerp(currentRotation, desiredRotation, Time.deltaTime * slerpSpeed);

//        // Ensure the camera always looks at the car
//        if (Mathf.Abs(horizontalInput) < 0.01f)
//        {
//            // If no steering input, reset the rotation to center
//            transform.forward = car.position - transform.position;
//        }
//        else
//        {
//            // If steering input, adjust the forward direction based on car position
//            transform.forward = Vector3.Slerp(transform.forward, car.position - transform.position, Time.deltaTime * slerpSpeed);
//        }
//    }
//}
//{
//    public Transform car; // The car transform

//    public float rotationSpeed = 5f; // Speed of camera rotation
//    public float rotationLerpFactor = 0.1f; // Lerp factor for smooth rotation

//    void Update()
//    {
//        HandleRotation();
//    }

//    void HandleRotation()
//    {
//        // Get the horizontal input for rotation
//        float horizontalInput = Input.GetAxis("Horizontal");

//        // Calculate the desired rotation angle based on the input
//        float targetRotation = car.eulerAngles.y + horizontalInput * rotationSpeed;

//        // Convert the target rotation to the -180 to 180 range


//        // Use Quaternion.Slerp to smoothly interpolate the rotation based on steering input
//        Quaternion currentRotation = transform.rotation;
//        Quaternion desiredRotation = Quaternion.Euler(0, targetRotation, 0);

//        float slerpSpeed = 0.5f * Mathf.Abs(horizontalInput); // Adjust slerp speed based on steering input
//        transform.rotation = Quaternion.Slerp(currentRotation, desiredRotation, Time.deltaTime * slerpSpeed);

//        // Ensure the camera always looks at the car
//        transform.forward = Vector3.Slerp(transform.forward, car.position - transform.position, Time.deltaTime * slerpSpeed);
//    }
//}
//    public Transform car; // The car transform

//    public float rotationSpeed = 5f; // Speed of camera rotation
//    public float rotationLerpFactor = 0.1f; // Lerp factor for smooth rotation

//    void Update()
//    {
//        HandleRotation();
//    }

//    void HandleRotation()
//    {
//        // Get the horizontal input for rotation
//        float horizontalInput = Input.GetAxis("Horizontal");

//        // Calculate the desired rotation angle based on the input
//        float targetRotation = car.eulerAngles.y + horizontalInput * rotationSpeed;

//        // Convert the target rotation to the -180 to 180 range
//        targetRotation = Mathf.Repeat(targetRotation + 180f, 360f) - 180f;

//        // Lerp between the current rotation and the desired rotation
//        Quaternion currentRotation = transform.rotation;
//        Quaternion desiredRotation = Quaternion.Euler(0, targetRotation, 0);

//        // Lerp to smoothly interpolate the rotation
//        transform.rotation = Quaternion.Lerp(currentRotation, desiredRotation, rotationLerpFactor);

//        // Ensure the camera always looks at the car
//        transform.forward = car.position - transform.position;
//    }
//}

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


