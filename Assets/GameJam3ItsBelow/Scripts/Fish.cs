using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject wayPoint1, wayPoint2;
    
    public float wanderRadius;
    public float wanderTimer;
 
    private Transform target;
    
    private float timer;
    // Start is called before the first frame update
    void OnEnable()
    {
        if(isActiveAndEnabled)
        {
            timer = wanderTimer;
            agent = GetComponent<NavMeshAgent>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActiveAndEnabled)
        {
            timer += Time.deltaTime;
            RandomMovement();
        }

    }

    void RandomMovement()
    {
        if (timer >= wanderTimer) {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    // void Travel()
    // {
    //     Vector3 wayp = wayPoint2.transform.position;
    //     agent.destination = wayp;
    // }

    // void SwapDestination()
    // {
    //     if(!agent.hasPath)
    //     {
    //         Vector3 nextWayp = wayPoint1.transform.position;
    //         agent.destination = nextWayp;
    //     }
    // }
    
    
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) 
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }

    
}
