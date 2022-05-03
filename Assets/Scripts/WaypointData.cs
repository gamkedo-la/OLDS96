using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointData : MonoBehaviour
{
    public WaypointData next;
    public void OnDrawGizmos(){
        if(next){
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, next.transform.position); //draw red line to next waypoint (in editor)
        }
    }

    void Update(){
        Debug.Log("Waypoint update reached");
        if(Input.GetKeyUp(KeyCode.Space)){
            Debug.Log("this code reached");
        }
    }
}
