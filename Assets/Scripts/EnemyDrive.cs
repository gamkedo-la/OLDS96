using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrive : MonoBehaviour
{
    private float initialVelocity = 0.0f; //target vel to decel to, maybe just use 0.0f
    public float finalVelocity = 500.0f; //added each sec while accelerating    

    public float driftPercent = 0.1f;

    public float accelerationRate = 200.0f; //added each sec while accelerating
    private float decelerationRate = 50.0f; //added each sec while accelerating

    //private float power = 0.0f; //the power applied to the car
    private float currentVelocity = 0.0f; //self-explanatory
    public float brakeDecayPercent = 0.0f; //self-explanatory

    //private float power; //don't think i need this anymore

    public float turnRate = 10.0f;
    public Transform restartAt;
    public Transform wayPoint;

    public DemoFunctionCallOnMe spacebarWillCallFunctionOn;

    private Rigidbody rb;//Rigidbody is one word, not camelcase

    private bool cinderBlock = false;

    // Start is called before the first frame update
    void Start()
    {
     rb = gameObject.GetComponent<Rigidbody>(); //template notation it's a func
     RestartAtSpawn();
    }

    public void RestartAtSpawn(){
        transform.position = restartAt.position;
        transform.rotation = restartAt.rotation;
    }

    // Update is called once per frame

    protected float AngleAroundAxis (Vector3 dirA, Vector3 dirB, Vector3 axis) {
		dirA = dirA - Vector3.Project(dirA, axis);
		dirB = dirB - Vector3.Project(dirB, axis);
		float angle = Vector3.Angle(dirA, dirB);
		return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);

        // for ref Vector3 pathToSteerToward = (safetyPoint - transform.position) + (nextWaypoint - transform.position);
        // i think transform.position can be used as a vector, not sure, but let's find out
	}

    void Update()
    {

        if(Input.GetKeyUp(KeyCode.Space)){
            cinderBlock = !cinderBlock;
        }
        
        //transform.Rotate(Vector3.up, turnRate * Time.deltaTime * Input.GetAxisRaw("Horizontal"));
        //^ i think you would actually remove the input, and replace turnRate with whatever the turn function outputs
        //rb.angularVelocity += turnRate * Time.deltaTime * Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate(){

        Vector3 flatForward = transform.forward;
        flatForward.y = 0.0f;
        float turnAmt = AngleAroundAxis(transform.forward, wayPoint.position - transform.position, Vector3.up);

        if(cinderBlock == true)
        {
            currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
        }
        else
        {
            currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
        }

        //ensure the velocity never goes out of the initial/final boundaries
        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);

        //power = power + (Time.deltaTime * currentVelocity);        

        if(cinderBlock == true) //forward
        {
            rb.velocity = rb.velocity*driftPercent + (1.0f - driftPercent) * flatForward * currentVelocity; //vel ALREADY takes place over time
            transform.Rotate(Vector3.up, turnAmt * Time.deltaTime);
        }
        else if((cinderBlock == false)) //brake
        {
            //rb.velocity = flatForward * -40.0f; //has the effect of immediately reversing the car
            //rb.velocity = rb.velocity*driftPercent + (1.0f - driftPercent) * flatForward * currentVelocity * currentBrake;
            rb.velocity = rb.velocity * brakeDecayPercent;
        }
        // if above conditions aren't met, the vehicle will decelerate

    }
}
