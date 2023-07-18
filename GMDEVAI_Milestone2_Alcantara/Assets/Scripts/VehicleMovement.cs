using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public Transform goal;
    public float speed;
    public float rotSpeed;

    public float acceleration;
    public float deceleration;
    public float minSpeed;
    public float maxSpeed;

    public float breakAngle;

    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime * rotSpeed);

        //speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);

        if (Vector3.Angle(goal.forward, this.transform.forward) > breakAngle && speed > 1)
        {
            speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else 
        {
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        
        this.transform.Translate(0, 0, speed);
    }

}
