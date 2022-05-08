using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
   
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider collider) 
    {
        if (isTriggered)
        {
            return;
        }
        if (collider.gameObject.tag == "Player") 
        {
            SceneManager.LoadScene("TitleScreen");
            isTriggered = true; 
        }
    }
}
