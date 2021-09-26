using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Transform effect;
    public Rock rock;

    private void OnTriggerStay(Collider other){
        Debug.Log("Skill Trigger");
        if(other.gameObject.CompareTag("Devil")&&effect.GetComponent<ParticleSystem> ().isPlaying){

            Vector3 dirrection=other.transform.position-transform.position;
            dirrection.y=0;
            other.GetComponent<Rigidbody>().AddForce(dirrection*7);
        }


        if(other.gameObject.CompareTag("Rock")&&effect.GetComponent<ParticleSystem> ().isPlaying){
            Vector3 dirrection=other.transform.position-transform.position;
            dirrection.y=0;
            other.GetComponent<Rigidbody>().AddForce(dirrection*7);
            rock.Shoot();
        }
    }
}
