using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public float rotationSpeed;

    void Start()
    {
    }

    void Update()
    {
        transform.RotateAround(transform.position,Vector3.up,rotationSpeed*Time.deltaTime);
    }
}
