using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private int count;
    private bool shoot;
    private float shoot_start;

    private GameObject[] pick_up;
    private Vector3 initial_position;
    public Boss boss;

    public void Shoot(){
        shoot=true;
        shoot_start=Time.fixedTime;
    }
    public void Start(){
        count=0;
        shoot=false;
        initial_position= transform.position;

        
                pick_up = GameObject.FindGameObjectsWithTag("Pick Up");
                Debug.Log("Pick Up length "+pick_up.Length);
                for(int i =0;i< pick_up.Length;i++){
                    pick_up[i].SetActive(false);
                }
    }

    void Update(){
        if(shoot==true){
            if(Time.fixedTime-shoot_start>2){
                transform.position=initial_position;
            }
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Rebound")){
            boss.rotationSpeed=0;
            count++;
            Debug.Log("Boss count:"+count);
            
            if(count==2){
                boss.gameObject.SetActive(false);
            
                Debug.Log("Pick Up length "+pick_up.Length);
                for(int i =0;i< pick_up.Length;i++){
                    pick_up[i].SetActive(true);
                }
            }
        }
    }
}
