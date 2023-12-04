using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform car;
    private Rigidbody carRb;
    [SerializeField] float camHeight = 1;
    [SerializeField] float camDistance = 1;
    [SerializeField] float rotationOffset = 0f;
    Vector3 lastVel = Vector3.forward;


    void Awake()
    {
        carRb = car.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Position
        Vector3 vel = carRb.velocity;
        if (vel.magnitude < 1)
        {
            vel = -lastVel.normalized;
        }
        else
        {
            lastVel = carRb.velocity;
            vel = -carRb.velocity;
        }
        vel += Vector3.right * Input.GetAxis("Horizontal");
        Vector3 camDirection = ClampMagnitude(vel, camDistance, camDistance + 1);

        transform.position = Vector3.Lerp(transform.position, car.position + camDirection + Vector3.up * camHeight, Time.deltaTime * 5);

        //Rotation
        //Quaternion lookDirection = Quaternion.LookRotation(car.position - transform.position);
        //lookDirection *= Quaternion.LookRotation(Vector3.right * Input.GetAxisRaw("Horizontal"));

        transform.rotation = Quaternion.LookRotation(car.position - transform.position) * Quaternion.Euler(Vector3.right * rotationOffset);

    }





    public static Vector3 ClampMagnitude(Vector3 v, float min, float max)
    {
        double sm = v.sqrMagnitude;
        if (sm > (double)max * (double)max) return v.normalized * max;
        else if (sm < (double)min * (double)min) return v.normalized * min;
        return v;
    }
    //[SerializeField] private Transform car;
    //private Rigidbody carRb;
    //[SerializeField] float camHeight = 1;
    //[SerializeField] float camDistance = 1;
    //Vector3 lastVel = Vector3.forward;


    //void Awake()
    //{
    //    carRb = car.gameObject.GetComponent<Rigidbody>();
    //}

    //void Update()
    //{
    //    //Position
    //    Vector3 vel = carRb.velocity;   
    //    if(vel.magnitude < 1)
    //    {
    //        vel = -lastVel.normalized;
    //    }
    //    else
    //    {
    //        lastVel = carRb.velocity;
    //        vel = -carRb.velocity;
    //    }
    //    vel += Vector3.right * Input.GetAxis("Horizontal");
    //    Vector3 camDirection = ClampMagnitude(vel, camDistance, camDistance + 1);

    //    transform.position = Vector3.Lerp(transform.position,car.position + camDirection + Vector3.up * camHeight, Time.deltaTime*5);

    //    //Rotation
    //    //Quaternion lookDirection = Quaternion.LookRotation(car.position - transform.position);
    //    //lookDirection *= Quaternion.LookRotation(Vector3.right * Input.GetAxisRaw("Horizontal"));

    //    transform.rotation = Quaternion.LookRotation(car.position - transform.position);

    //}





    //public static Vector3 ClampMagnitude(Vector3 v, float min, float max)
    //{
    //    double sm = v.sqrMagnitude;
    //    if (sm > (double)max * (double)max) return v.normalized * max;
    //    else if (sm < (double)min * (double)min) return v.normalized * min;
    //    return v;
    //}

}


