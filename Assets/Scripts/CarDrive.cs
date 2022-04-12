using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{

    private float initialVelocity = 0.0f; //target vel to decel to, maybe just use 0.0f
    public float finalVelocity = 500.0f; //added each sec while accelerating    

    public float driftPercent = 0.1f;

    public float accelerationRate = 200.0f; //added each sec while accelerating
    private float decelerationRate = 50.0f; //added each sec while accelerating

    //private float power = 0.0f; //the power applied to the car
    private float currentVelocity = 0.0f; //self-explanatory
    public float brakeDecayPercent = 0.0f; //self-explanatory

    public float turnRate = 10.0f;
    public Transform restartAt;

    private Rigidbody rb;//Rigidbody is one word, not camelcase

    // Start is called before the first frame update
    void BaseStart()
    {
        rb = gameObject.GetComponent<Rigidbody>(); //template notation it's a func
        RestartAtSpawn();   
    }

    public void RestartAtSpawn(){
        transform.position = restartAt.position;
        transform.rotation = restartAt.rotation;
    }

    // Update is called once per frame
    void BaseUpdate(int inputType) //something like this?
    {
        Vector3 flatForward = transform.forward;
        flatForward.y = 0.0f;   


        if(true) //change to if accel is tru
        {
            currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
        }
        else
        {
            currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
        }

        //ensure the velocity never goes out of the initial/final boundaries
        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);

    }
}
