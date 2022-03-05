using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour {
    public static LapCounter instance;
    public Text lapUI;
    private int lapCount = 0;

    void updateLapHUD(){
        lapUI.text = "" + lapCount + " laps"; //type conversion
    }

    public void addLap(){ //accessible from outside this script
        lapCount++;
        updateLapHUD();
        if(lapCount >= 3){
            lapUI.text = "u win!"; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this; //completes the singleton pattern
        updateLapHUD();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
