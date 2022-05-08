using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;
    public Image overlay;
    public Image pauseText;
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
                overlay.enabled = false;
                pauseText.enabled = false;
            } else {
                Pause();
                overlay.enabled = true;
                pauseText.enabled = true;
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
