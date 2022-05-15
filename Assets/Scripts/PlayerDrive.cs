using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarDrive))] //tells script it requires CarDrive
public class PlayerDrive : MonoBehaviour
{
    private CarDrive carDrive;

    // Start is called before the first frame update
    void Start()
    {
        carDrive = gameObject.GetComponent<CarDrive>();
        carDrive.BaseStart();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardRelative = transform.InverseTransformVector(carDrive.rb.velocity);
        if (Mathf.Abs(forwardRelative.z) > 2.0f){
            transform.Rotate(Vector3.up, (forwardRelative.z > 0.0f ? 1.0f : -1.0f) *
                carDrive.turnRate * Time.deltaTime * Input.GetAxisRaw("Horizontal"));
        }
        
        speedmeterarmscript.ShowSpeed(carDrive.rb.velocity.magnitude,0,100);
    }

    void FixedUpdate(){

        //Debug.Log(carDrive.rb.velocity);

        //current empty, will replace the lines below it
        carDrive.BaseUpdate(Input.GetKey(KeyCode.UpArrow));

        Vector3 flatForward = transform.forward;
        flatForward.y = 0.0f;   

        if(Input.GetAxisRaw("Vertical") > 0.0f)
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


        if(Input.GetAxisRaw("Vertical") > 0.0f) //forward
        {
            carDrive.rb.velocity = carDrive.rb.velocity*carDrive.driftPercent + (1.0f - carDrive.driftPercent) * flatForward * carDrive.currentVelocity; //vel ALREADY takes place over time
        }
        else if(Input.GetAxisRaw("Vertical") < 0.0f) //brake
        {
            Vector3 forwardRelative = transform.InverseTransformVector(carDrive.rb.velocity);
            if (forwardRelative.z > 0.1) { // any forward speed? decelerate
                carDrive.rb.velocity = carDrive.rb.velocity * carDrive.brakeDecayPercent;
            } else { // virtually no forward speed? throw it into weak reverse
                carDrive.rb.velocity = carDrive.rb.velocity * carDrive.driftPercent + 
                                (1.0f - carDrive.driftPercent) * flatForward * -3.0f;
            }
        }
        // if above conditions aren't met, the vehicle will decelerate

    }
}
