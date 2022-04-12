using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CarDrive))] //tells script it requires CarDrive
public class PlayerDrive : MonoBehaviour
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

    public DemoFunctionCallOnMe spacebarWillCallFunctionOn;

    private Rigidbody rb;//Rigidbody is one word, not camelcase

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

    void Update()
    {
        transform.Rotate(Vector3.up, turnRate * Time.deltaTime * Input.GetAxisRaw("Horizontal"));
        //rb.angularVelocity += turnRate * Time.deltaTime * Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate(){

        Vector3 flatForward = transform.forward;
        flatForward.y = 0.0f;
        //Debug.Log(rb.velocity);

        if(Input.GetKey(KeyCode.UpArrow))
        {
            //add to the current velocity according while accelerating
            currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
        }
        else
        {
            //subtract from the current velocity while decelerating
            currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
        }

        //ensure the velocity never goes out of the initial/final boundaries
        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);

        //power = power + (Time.deltaTime * currentVelocity);        

        if(Input.GetAxisRaw("Vertical") > 0.0f) //forward
        {
            rb.velocity = rb.velocity*driftPercent + (1.0f - driftPercent) * flatForward * currentVelocity; //vel ALREADY takes place over time
        }
        else if((Input.GetAxisRaw("Vertical") < 0.0f)) //brake
        {
            //rb.velocity = flatForward * -40.0f; //has the effect of immediately reversing the car
            //rb.velocity = rb.velocity*driftPercent + (1.0f - driftPercent) * flatForward * currentVelocity * currentBrake;
            rb.velocity = rb.velocity * brakeDecayPercent;
        }
        // if above conditions aren't met, the vehicle will decelerate

    }
}
