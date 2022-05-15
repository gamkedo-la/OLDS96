using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;
    public Image overlay;
    public Image pauseText;
    public Button resumeButton;
    public Button quitButton;
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

    public void Pause() {
        Time.timeScale = 0f;
        isPaused = true;
        overlay.enabled = true;
        pauseText.enabled = true;
        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void Resume() {
        Time.timeScale = 1f;
        isPaused = false;
        overlay.enabled = false;
        pauseText.enabled = false;
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }
}
