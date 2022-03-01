using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBonus : MonoBehaviour
{
    private bool istriggered = false; 

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player"){
            //timerScript.timeRemaining += 200;
            //Debug.Log('time bonus!');
            Debug.Log("time bonus!");
        }
        istriggered = true;    
    }
    
    void OnTriggerExit( Collider coll)
    {
        istriggered  = false;
    }
}
