using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBonus : MonoBehaviour
{
    private bool isTriggered = false; 

    private void OnTriggerEnter(Collider collider)
    {
        if(isTriggered){
            return;
        }
        if(collider.gameObject.tag == "Player"){
            //timerScript.timeRemaining += 200;
            //Debug.Log('time bonus!');
            Debug.Log("time bonus!");
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
