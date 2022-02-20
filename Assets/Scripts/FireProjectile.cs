using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Assign a Rigidbody component in the inspector to instantiate

    public GameObject projectile;

    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the projectile at the position and rotation of this transform
            GameObject clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);
            Rigidbody cloneRb = clone.GetComponent<Rigidbody>();
            //Debug.Log(transform.position);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            cloneRb.velocity = transform.TransformDirection(Vector3.forward * 2);
            //clone.velocity = transform.TransformDirection(Vector3.forward * 2);
        }
    }
}
