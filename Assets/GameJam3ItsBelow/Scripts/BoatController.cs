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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ToggleBoat()
    {
        originalPos = player.transform;
        player.transform.position = captainsSpot.transform.position;
       
        
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
