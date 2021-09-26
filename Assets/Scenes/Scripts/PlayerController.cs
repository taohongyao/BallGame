using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Transform effect;
    public GameObject boss;
    private int count;
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;

    private Vector3 initial_position;

    void Start (){
        count=0;
        rb=GetComponent<Rigidbody>();
        SetCountText();
        winText.text="";
        initial_position = transform.position;
    }
    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
    
        Vector3 movement= new Vector3 (moveHorizontal,0.0f,moveVertical);

        rb.AddForce(movement*speed);
        changeBossColor();

    }

    void Update(){

        if (Input.GetKeyDown("space"))
        {
            effect.GetComponent<ParticleSystem> ().Play();
        }
    }


    private void changeBossColor(){
        float distance=Vector3.Distance(boss.transform.position,transform.position);
        Debug.Log("Distance "+distance);
        if(distance<8){
            boss.GetComponent<Renderer>().material.SetColor("_Color",new Color(1,1*((distance-1.3f)/8),0,1));
            Debug.Log("boss.GetComponent<Renderer>().material "+boss.GetComponent<Renderer>().material.color);
        }else{
            boss.GetComponent<Renderer>().material.SetColor("_Color",new Color(1,1,0,1));
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Devil")||collision.gameObject.CompareTag("Trap")){
            restart();
        }
    }

    public void restart(){
        transform.position=initial_position;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if(other.gameObject.CompareTag("Trap")){
            restart();
        }


    }

    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Rebound")){

            Vector3 dirrection=transform.position-other.transform.position;
            Debug.Log("Rebound "+dirrection);
            dirrection.y=0;

            rb.AddForce(dirrection*200);
        }
    }


    void SetCountText(){
        countText.text="Count: "+count.ToString();
        if(count>=12){
            winText.text="You Win!";
        }
    }
    
    

    
    
}
