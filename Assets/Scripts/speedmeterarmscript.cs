using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedmeterarmscript : MonoBehaviour
{

    static float minAngle = 200.0f;
    static float maxAngle = 0.0f;
    static speedmeterarmscript thisSpeedo;
    // Start is called before the first frame update
     void Start()
    {
        thisSpeedo = this;
    }

    // Update is called once per frame
    public static void ShowSpeed(float speed, float min, float max)
    {
        float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(min, max, speed));
        if(thisSpeedo){
            thisSpeedo.transform.eulerAngles = new Vector3(0,0,ang);
        } else {
            Debug.LogWarning("thisSpeedo reference lost");
        }
    }
}
