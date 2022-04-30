using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera enemyCamera;

    // Call this function to disable main camera,
    // and enable enemy camera.
    public void ShowEnemyView() {
        mainCamera.enabled = false;
        enemyCamera.enabled = true;
    }
    
    // Call this function to enable main camera,
    // and disable enemy camera.
    public void ShowMainView() {
        mainCamera.enabled = true;
        enemyCamera.enabled = false;
    }
}

