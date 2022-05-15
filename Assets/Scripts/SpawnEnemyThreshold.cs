using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyThreshold : MonoBehaviour
{
    public GameObject EnemySpawnPoint;
    private SpawnEnemies enemySpawnScript;
    private bool isTriggered = false; 

    //private enemySpawnScript = EnemySpawnPoint.GetComponent<SpawnEnemies>();

    void Start (){
        if(EnemySpawnPoint){
            enemySpawnScript = EnemySpawnPoint.GetComponent<SpawnEnemies>();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {

        if(isTriggered){
            return;
        }
        if(collider.gameObject.tag == "Player"){
            Debug.Log(collider.gameObject.name + " triggered " +gameObject.name);
            enemySpawnScript.SpawnEnemy(); 
            isTriggered = true;   
        }
 
    }
    
    void OnTriggerExit( Collider coll)
    {
        if(coll.gameObject.tag == "Player"){
            isTriggered  = false;
        }
    }
}
