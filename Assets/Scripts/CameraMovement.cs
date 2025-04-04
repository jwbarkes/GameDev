using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 offset;
    public GameObject car;

    void Update()
    {
        transform.position = car.transform.position + offset;
        transform.LookAt(car.transform.position);
    }
}
