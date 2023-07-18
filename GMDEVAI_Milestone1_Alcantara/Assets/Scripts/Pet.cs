using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public Transform player;
    float speed = 2;
    float rotationSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookAtPlayer = new Vector3(player.position.x, this.transform.position.y, player.position.z);

        Vector3 direction = lookAtPlayer - transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                                                   Quaternion.LookRotation(direction), 
                                                   Time.deltaTime * rotationSpeed);

        if (Vector3.Distance(lookAtPlayer, transform.position) > 1)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
