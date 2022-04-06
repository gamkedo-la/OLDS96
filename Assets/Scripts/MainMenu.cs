using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

// these functions are called by the main menu gui buttons onClick

public class MainMenu : MonoBehaviour
{
    public string button1SceneName = "paperBoyClone";
    public string button2SceneName = "level2";
    public string button3SceneName = "SampleScene 1";
    public string creditsSceneName = "Credits";
 
    public void onClickButton1() {  
        SceneManager.LoadScene(this.button1SceneName);  
    }  
    public void onClickButton2() {  
        SceneManager.LoadScene(this.button2SceneName);
    }  
    public void onClickButton3() {  
        SceneManager.LoadScene(this.button3SceneName);
    }  
    public void onClickCreditsButton() {  
        SceneManager.LoadScene(this.creditsSceneName);
    }  


}
