using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarDrive))] //tells script it requires CarDrive
public class EnemyDrive : MonoBehaviour
{

    private CarDrive carDrive;

    public Transform wayPoint;
    public Transform wayPoint2;

    //testing to see if i can get the whole game object
    public GameObject wayPointWhole;

    // ^ going to write some better variables
    public GameObject wayPointSpawnedAt;
    public WaypointData wayPointData;
    private Transform nextWayPoint;

    //private Transform currentWayPoint = wayPoint; ask Chris why this throws an error
    private Transform currentWayPoint;

    private bool cinderBlock = false;

    void OnCollisionEnter(Collision coll){
        if(LayerMask.LayerToName(coll.collider.gameObject.layer) == "Player"){
            Vector3 relativeHitPt = transform.InverseTransformPoint(coll.contacts[0].point); //makes it relative to the point hit
            float angle = Mathf.Atan2(relativeHitPt.x, relativeHitPt.z) * Mathf.Rad2Deg;
            Debug.Log(coll.collider.gameObject.name + " " + angle);
            float frontBackAngRange = 40.0f;
            if(Mathf.Abs(angle) < frontBackAngRange/2){
                Debug.Log("hit from front");
            } else if (angle > 0.0f && angle < 180.0f - frontBackAngRange/2) {
                Debug.Log("hit from right");
            } else if (angle < 0.0f && angle > -180.0f + frontBackAngRange/2) {
                Debug.Log("hit from left");
            } else {
                Debug.Log("hit from back");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        carDrive = gameObject.GetComponent<CarDrive>();
        carDrive.BaseStart();
        currentWayPoint = wayPoint;
        nextWayPoint = wayPointSpawnedAt.GetComponent<WaypointData>().next.transform;
    }

    protected float AngleAroundAxis (Vector3 dirA, Vector3 dirB, Vector3 axis) {
		dirA = dirA - Vector3.Project(dirA, axis);
		dirB = dirB - Vector3.Project(dirB, axis);
		float angle = Vector3.Angle(dirA, dirB);
		return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
	}

    // Update is called once per frame
    void Update()
    {
 
    }

    void FixedUpdate(){

        Vector3 flatForward = transform.forward;
        flatForward.y = 0.0f;   

        if(Input.GetKeyUp(KeyCode.Space)){
            cinderBlock = !cinderBlock;
        }  

        //TODO set accel to true based on cinderblock

        float distTo = Vector3.Distance(transform.position, nextWayPoint.position);
		float closeEnoughToWaypoint = 10.0f;
		if(distTo < closeEnoughToWaypoint) {
            //currentWayPoint = wayPoint2; change to next, current doesn't really make sense
            nextWayPoint = nextWayPoint.GetComponent<WaypointData>().next.transform;
        }

        float turnAmt = AngleAroundAxis(transform.forward, nextWayPoint.position - transform.position, Vector3.up);

        carDrive.BaseUpdate(cinderBlock);

        if(cinderBlock == true) //forward
        {
            carDrive.rb.velocity = carDrive.rb.velocity*carDrive.driftPercent + (1.0f - carDrive.driftPercent) * flatForward * carDrive.currentVelocity; //vel ALREADY takes place over time
            transform.Rotate(Vector3.up, turnAmt * Time.deltaTime);
        }
        else if((cinderBlock == false)) //brake
        {
            if(carDrive == null){
                Debug.Log("carDrive missing");
            } 
            else if(carDrive.rb == null){
                Debug.Log("rb is missing");
            }
            
            carDrive.rb.velocity = carDrive.rb.velocity * carDrive.brakeDecayPercent;
            
        }
        // if above conditions aren't met, the vehicle will decelerate

    }
}
