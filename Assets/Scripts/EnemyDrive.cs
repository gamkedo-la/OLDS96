using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarDrive))] //tells script it requires CarDrive
public class EnemyDrive : MonoBehaviour
{

    //remove below once you learn how to reference the CameraSwitch script
    public Camera mainCamera;
    public Camera enemyCamera;


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

    //REMOVE BELOW HELPER FUNCTIONS ONCE CAMSWITCH SCRIPT WORKS
    // Call this function to disable main camera,
    // and enable enemy camera.
    public void ShowEnemyView() {
        mainCamera.enabled = false;
        enemyCamera.enabled = true;
    }    
    // Call this function to enable main camera,
    // and disable enemy camera.
    public void ShowMainView() {
        mainCamera.enabled = true;
        enemyCamera.enabled = false;
    }

    void OnCollisionEnter(Collision coll){
        if(LayerMask.LayerToName(coll.collider.gameObject.layer) == "Player"){
            Vector3 relativeHitPt = transform.InverseTransformPoint(coll.contacts[0].point); //makes it relative to the point hit
            float angle = Mathf.Atan2(relativeHitPt.x, relativeHitPt.z) * Mathf.Rad2Deg;
            Debug.Log(coll.collider.gameObject.name + " " + angle);
            //note about tuning ranges: think about placing the van on a clock, the more "hours" a side occupies, the bigger it's range
            //this is why (at the time of oo) front/back is 20.0 and the sides are 160.0, adds up to 180, but the sides are way bigger

            //TODO: implement a collision cool down so you aren't double blasting the enemy van with force
            //when you implement addForce or addForcePosition, use a BIG multiplier, the physics units are tiny and might not show visible change
            //even if they are working
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
        //cameraSwitch = gameObject.GetComponent<CameraSwitch>();
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
        if(Input.GetKeyUp(KeyCode.Space)){
            cinderBlock = !cinderBlock;
        }  

        if(cinderBlock){
            ShowEnemyView();
        }

        else if(!cinderBlock){
            ShowMainView();
        }


        //Debug.Log(cameraSwitch);

        /*
        if(cinderBlock){
            cameraSwitch.ShowEnemyView();
        }

        else if(!cinderBlock){
            cameraSwitch.ShowMainView();
        }
        */
    }

    void FixedUpdate(){

        Vector3 flatForward = transform.forward;
        flatForward.y = 0.0f;   

        //TODO set accel to true based on cinderblock

        float distTo = Vector3.Distance(transform.position, nextWayPoint.position);
		float closeEnoughToWaypoint = 10.0f;
		if(distTo < closeEnoughToWaypoint) {
            //currentWayPoint = wayPoint2; change to next, current doesn't really make sense
            nextWayPoint = nextWayPoint.GetComponent<WaypointData>().next.transform;
        }

        float turnAmt = AngleAroundAxis(transform.forward, nextWayPoint.position - transform.position, Vector3.up);

        carDrive.BaseUpdate(cinderBlock);

        if(cinderBlock)
        {
            //add to the current velocity according while accelerating
            carDrive.currentVelocity = carDrive.currentVelocity + (carDrive.accelerationRate * Time.deltaTime);
        }
        //else if(Input.GetAxisRaw("Vertical") < 0.0f)
        else
        {
            //subtract from the current velocity while decelerating
            carDrive.currentVelocity = carDrive.currentVelocity - (carDrive.decelerationRate * Time.deltaTime);
        }

        //ensure the velocity never goes out of the initial/final boundaries
        carDrive.currentVelocity = Mathf.Clamp(carDrive.currentVelocity, carDrive.initialVelocity, carDrive.finalVelocity);  


        if(cinderBlock == true) //forward
        {
            Debug.Log(carDrive.rb.velocity);
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
