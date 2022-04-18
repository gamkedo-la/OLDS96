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
        transform.Rotate(Vector3.up, carDrive.turnRate * Time.deltaTime * Input.GetAxisRaw("Horizontal"));
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
        else if(Input.GetAxisRaw("Vertical") < 0.0f)
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
        else if((Input.GetAxisRaw("Vertical") < 0.0f)) //brake
        {
            carDrive.rb.velocity = carDrive.rb.velocity * carDrive.brakeDecayPercent;
        }
        // if above conditions aren't met, the vehicle will decelerate

    }
}
