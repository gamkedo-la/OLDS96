using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomWhileDriving : MonoBehaviour {

    GameObject parent;

    public Camera cam;
    public GameObject target;
    public float zoomSpeed = 5;
    public float maxFOV = 80f;
    public float minFOV = 60f;
    private float t = 0.8f;

	// Use this for initialization
	void Start () {
        parent = gameObject.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        Zoom();
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
    }

    void Zoom ()
    {
        if (Input.GetKey("up")) {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, maxFOV, t * Time.deltaTime * zoomSpeed);
            t = t * t * (3f - 2f * t);
        } else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, minFOV, t * Time.deltaTime);
        }
    }
}
