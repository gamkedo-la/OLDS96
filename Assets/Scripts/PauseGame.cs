using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    void Pause() {
        Time.timeScale = 0f;
        isPaused = true;
    }

    void Resume() {
        Time.timeScale = 1f;
        isPaused = false;
    }
}
