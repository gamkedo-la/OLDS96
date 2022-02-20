using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashIntoMe : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("CrashIntoMe has run");
    }

    private void OnCollisionEnter(Collision collision){

        CarDrive cdScript = collision.collider.gameObject.GetComponentInParent<CarDrive>();

        if(cdScript != null){
            Debug.Log("Collided with player");
            cdScript.RestartAtSpawn();
        } else {
            Debug.Log("I " + gameObject.name + " got bumped by " + collision.collider.gameObject.name);
        } //end of else
    } //end of collision function
} //end of class