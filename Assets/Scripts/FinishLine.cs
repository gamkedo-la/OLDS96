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
        if(isTriggered){
            return;
        }
        if(collider.gameObject.tag == "Player"){
            LapCounter.instance.addLap(); //script.instance.method
            //TimerClass.instance.addTime(); //currently breaks build
            //Debug.Log(TimerClass.instance);
            //Debug.Log(LapCounter.instance);
            isTriggered = true;
        }        
    }
    
    void OnTriggerExit( Collider coll){
        if(coll.gameObject.tag == "Player"){
            isTriggered  = false;
        }
    }
}
