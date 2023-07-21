using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    void Update()
    {
        this.transform.position = player.transform.position + new Vector3(0, 30, -5);
    }
}
    