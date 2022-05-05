using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject van;
    private GameObject vanInstance;
    private EnemyDrive enemyDriveScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)){
            //Debug.Log("space key pressed in waypoint");
            vanInstance = Instantiate(van, gameObject.transform);
            enemyDriveScript = vanInstance.GetComponent<EnemyDrive>();
            enemyDriveScript.wayPointSpawnedAt = gameObject;
        }   

    }
}