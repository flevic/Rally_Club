using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform car;
    [SerializeField] public bool lerp = true;
    private Rigidbody carRb;
    [SerializeField] public float camHeight = 1;
    [SerializeField] public float camDistance = 1;
    [SerializeField] public float rotationOffset = 0f;
    Vector3 lastVel = Vector3.forward;


    public void Init(GameObject _car)
    {
        car = _car.transform;
        carRb = car.gameObject.GetComponent<Rigidbody>();
    }


    Vector3 vel;
    Vector3 camDirection;
    void Update()
    {
        if(car == null) { return; }

        //Get car velocity, normalized it and invert it
        vel = carRb.velocity;
        if (vel.magnitude < 1)
        {
            vel = -lastVel.normalized;
        }
        else
        {
            lastVel = carRb.velocity;
            vel = -carRb.velocity;
        }

        //Add a horizontal offset to the velocity based on steering input
        vel += Vector3.right * Input.GetAxis("Horizontal");
        camDirection = ClampMagnitude(vel, camDistance, camDistance + 1);

        if (lerp)
        {
            LerpMove();
        }
        else
        {
            Move();
        }
    }

    //Lerp car follow
    void LerpMove()
    {
        // Set a fixed interpolation factor (adjust as needed)
        float lerpFactor = 1f;

        // Lerp to the target position with damping
        Vector3 targetPosition = car.position + camDirection + Vector3.up * camHeight;
        transform.position = Vector3.Slerp(transform.position, targetPosition, lerpFactor);

        // Lerp to the target rotation with damping
        Quaternion targetRotation = Quaternion.LookRotation(car.position - transform.position) * Quaternion.Euler(Vector3.right * rotationOffset);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lerpFactor);
        //Lerp to the target position
        //transform.position = Vector3.Lerp(transform.position, car.position + camDirection + Vector3.up * camHeight, Time.deltaTime * 100);

        ////Lerp to the target rotation
        //transform.rotation = Quaternion.LookRotation(car.position - transform.position) * Quaternion.Euler(Vector3.right * rotationOffset);
    }
    
    //Instant car follow
    void Move()
    {
        //Update position
        transform.position = car.TransformPoint(Vector3.forward * camDistance + Vector3.up * camHeight);
        //Update rotation
        transform.rotation = car.transform.rotation;
    }

    public static Vector3 ClampMagnitude(Vector3 v, float min, float max)
    {
        double sm = v.sqrMagnitude;
        if (sm > (double)max * (double)max) return v.normalized * max;
        else if (sm < (double)min * (double)min) return v.normalized * min;
        return v;
    }
}