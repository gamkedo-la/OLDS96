using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFInishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("CrossFinishLine has run");
    }
    
    private void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            Debug.Log("u win~" + collider.gameObject.tag);
        }
        
    }
}
