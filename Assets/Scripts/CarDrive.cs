using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{

    //private float velocity = 10.0;
    //private float acceleration = 10.0; //might be driveSpeed, nah better replaced iwth accel

    public float driveSpeed = 8.0f;
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
        if(Input.GetKeyDown(KeyCode.Space)){
            spacebarWillCallFunctionOn.TestFunctionality();
        }
        transform.Rotate(Vector3.up, turnRate * Time.deltaTime * Input.GetAxisRaw("Horizontal"));

    }

    void FixedUpdate(){

        /*
        //this line adds the acceleration value to the power value over the course of 1 second, up to infinity
        power = power + (Time.deltaTime * acceleration);
        //this line feeds the ever-growing force to the object, propelling it faster and faster over time
        transform.Translate(0, 0, power); //this is applied to the translate, not what we want, i think you want the rb
        */

        //float power = power + (Time.deltaTime * acceleration);

        rb.angularVelocity = Vector3.zero; //stop spinning out of control?
        rb.velocity *= 0.8f;
        Vector3 flatForward = transform.forward;
        flatForward.y = 0.0f;
        rb.velocity += flatForward * driveSpeed * Input.GetAxisRaw("Vertical"); //vel ALREADY takes place over time
        //rb.velocity += flatForward * power * Input.GetAxisRaw("Vertical"); //vel ALREADY takes place over time
        //Debug.Log(rb.velocity);
    }
}
