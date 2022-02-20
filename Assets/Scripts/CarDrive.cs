using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{

    public float driveSpeed = 8.0f;
    public float turnRate = 10.0f;
    public Transform restartAt;

    public DemoFunctionCallOnMe spacebarWillCallFunctionOn;

    private Rigidbody rb;//Rigidbody is one word, not camelcase

    // Start is called before the first frame update
    void Start()
    {
     rb = gameObject.GetComponent<Rigidbody>(); //template notation it's a func
     //Debug.Log("car object started script");   
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
        /*
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.position += transform.forward * Time.deltaTime * 3.0f;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(Vector3.up, 30.0f * Time.deltaTime);
        }
        */

        //transform.position += transform.forward * Time.deltaTime * driveSpeed * Input.GetAxisRaw("Vertical");
        
        transform.Rotate(Vector3.up, turnRate * Time.deltaTime * Input.GetAxisRaw("Horizontal"));

    }

    void FixedUpdate(){
        rb.angularVelocity = Vector3.zero; //stop spinning out of control?
        rb.velocity *= 0.8f;
        Vector3 flatForward = transform.forward;
        flatForward.y = 0.0f;
        rb.velocity += flatForward * driveSpeed * Input.GetAxisRaw("Vertical"); //vel ALREADY takes place over time
        //Debug.Log(rb.velocity);
    }
}