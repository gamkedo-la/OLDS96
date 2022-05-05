using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyThreshold : MonoBehaviour
{
    private bool isTriggered = false; 

    private void OnTriggerEnter(Collider collider)
    {
        if(isTriggered){
            return;
        }
        if(collider.gameObject.tag == "Player"){
            Debug.Log("spawn enemy time!");
            isTriggered = true;   
        }
 
    }
    
    void OnTriggerExit( Collider coll)
    {
        if(coll.gameObject.tag == "Player"){
            isTriggered  = false;
        }
    }
}
