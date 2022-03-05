using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("CrossFinishLine has run");
    }

    private bool isTriggered = false; 
 
    private void OnTriggerEnter(Collider collider){
        //Debug.Log("OnTriggerEnter has fired");
        //Debug.Log(istriggered);
        if  (isTriggered == false) {
            if(collider.gameObject.tag == "Player"){
                LapCounter.instance.addLap(); //script.instance.method
            }
            // do your things here that has to happen once
            isTriggered = true;
        }        
    }
    
    void OnTriggerExit( Collider coll)
    {
        isTriggered  = false;
    }
}
