using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossFinishLine : MonoBehaviour
{

    public Text lapCountDisplay;
    public TimerClass timerScript;
    private int lapCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("CrossFinishLine has run");
    }

    private bool istriggered = false; 
 
    private void OnTriggerEnter(Collider collider){
        //Debug.Log("OnTriggerEnter has fired");
        //Debug.Log(istriggered);
        if  (istriggered == false) {
            if(collider.gameObject.tag == "Player"){
                lapCount++;
                //timerScript.timeRemaining += 200;
                lapCountDisplay.text = lapCount.ToString();
                Debug.Log(lapCount);
                if(lapCount == 3){
                    Debug.Log("u win~" + collider.gameObject.tag);
                }
            }
            // do your things here that has to happen once
            istriggered = true;
        }        
    }
    
    void OnTriggerExit( Collider coll)
    {
        istriggered  = false;
    }

}
