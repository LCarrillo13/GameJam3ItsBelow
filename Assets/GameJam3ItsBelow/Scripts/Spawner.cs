using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjPooling OP;
    public Transform spawnPoint;
    public bool hasCorStarted;
    
    // Start is called before the first frame update

    void Awake()
    {
        OP = ObjPooling.SharedInstance;
        hasCorStarted = false;
    }

    private void Start()
    {
        StartCoroutine(FishSpawnDelay());
    }
    

    IEnumerator FishSpawnDelay()
    {
        for(int i = 0; i < 150; i++)
        {
            GameObject fishToSpawn = ObjPooling.SharedInstance.GetPooledObject(0);
            // FishSpawn();
       
            fishToSpawn.transform.position = spawnPoint.position;
            fishToSpawn.transform.rotation = spawnPoint.rotation;
            fishToSpawn.SetActive(true);
            Debug.Log("fish spawned");
            yield return new WaitForSeconds(0.25f);
        }
    }


}
