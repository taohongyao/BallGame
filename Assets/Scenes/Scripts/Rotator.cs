using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 scaleChange;
    public float rotationSpeed;
    public float scaleSpeed;
    public int scale_interval;
    private float x;

    void Start()
    {

    }

    void Update()
    {
        // transform.RotateAround(transform.position,Vector3.up,rotationSpeed*Time.deltaTime);
        transform.Rotate(new Vector3(30,45,15)*Time.deltaTime);

        

        if(Time.frameCount%scale_interval==0){
            scaleChange*=-1;
        }
        transform.localScale+=scaleChange*Time.deltaTime*scaleSpeed;
    }
}
