using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public string button1SceneName = "TitleScreen";
    public string button2SceneName = "paperBoyClone";
    

    public void onClickButton1()
    {
        SceneManager.LoadScene(this.button1SceneName);
    }
    public void onClickButton2()
    {
        SceneManager.LoadScene(this.button2SceneName);
    }
   


}
