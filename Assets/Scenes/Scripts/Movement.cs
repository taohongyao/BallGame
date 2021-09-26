using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rb;
    private float direction_x;
    private float direction_z;
    public float moveSpeed;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        float angle=Random.Range(0f,360);
        direction_x= Mathf.Sin(angle)*moveSpeed;
        direction_z=Mathf.Cos(angle)*moveSpeed;
        if(angle<90){
            direction_x*=-1;
        }else if(angle < 180){

        }else if(angle < 270){
            direction_z*=-1;
        }else{
            direction_x*=-1;
            direction_z*=-1;
        }
    }


    void FixedUpdate()
    {
        Debug.Log("direction_x "+direction_x);
        Debug.Log("direction_z "+direction_z);
        rb.AddForce(new Vector3(direction_x,0,direction_z)*5*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if(other.gameObject.CompareTag("North Wall")&&direction_z>0){
            direction_z*=-1;

            Debug.Log("Z change");
        }
        if(other.gameObject.CompareTag("South Wall")&&direction_z<0){
            direction_z*=-1;
        }
        if(other.gameObject.CompareTag("East Wall")&&direction_x>0){
            direction_x*=-1;
            Debug.Log("X change");
        }
        if(other.gameObject.CompareTag("West Wall")&&direction_x<0){
            direction_x*=-1;
        }
    }

}
