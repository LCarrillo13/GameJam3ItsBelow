using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    
    [SerializeField]
    public GameObject boat;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public GameObject playerCamera;
    [SerializeField] 
    public GameObject wheel;
    [SerializeField]
    public GameObject captainsSpot;
    public Transform originalPos;
    
    public void ToggleBoat()
    {
        originalPos = player.transform;
        player.transform.position = captainsSpot.transform.position;
       
        ToggleSteering();
        Debug.Log("Boat Toggled");
    }

    public void ToggleSteering()
    {
        Debug.Log("Steering Toggled");
    }

   public void OnCollisionEnter(Collision other)
   {
       if(other.gameObject.CompareTag("Player"))
       {
           ToggleBoat();
       }
   }
}
