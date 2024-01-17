using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
	//Movement
	private CharacterController characterController;
	public float speed = 5f;
	public float walkSpeed = 5f;
	public float runSpeed = 10f;
	public float strafeSpeed = 5f;
	public float rotationalSpeed = 5f;
	//Camera stuff
	public float cameraRotation;
	public float tiltSpeed = 5f;
	public float maxTiltAngle = 45f;
	// Raycast stuff
	public Transform playerCamera;
	public float maxFiringDistance = 100f;
	//Objectives
	public int fishScore = 0;
	public Text fishText;
	
#region UnityEvents

	private void Awake()
	{
		characterController = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		Move();
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			FireRod();
		}
		
	}
	
	
#endregion

 #region Movement
 public void Move()
	{
		float currentSpeed = IsRunning()
			? runSpeed
			: walkSpeed;
		float forwardSpeed = ForwardDirection() * currentSpeed;
		Vector3 movementDirection = (transform.forward * forwardSpeed) + (transform.right * SidewaysDirection() * strafeSpeed);
		characterController.Move(movementDirection * Time.deltaTime);
		//Camera rotation
		transform.rotation *= Quaternion.Euler(0, RotationY() * rotationalSpeed, 0);
		cameraRotation += TiltCamera() * tiltSpeed;
		cameraRotation = Mathf.Clamp(cameraRotation, -maxTiltAngle, maxTiltAngle);
		playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0, 0);
	}
 public float onScreenUpValue;
	public float onScreenDownValue;
	public float onScreenLeftValue;
	public float onScreenRightValue;
	private float OnScreenHorizontal
	{
		get { return onScreenRightValue - onScreenLeftValue; }
	}
	private float OnScreenVertical
	{
		get { return onScreenUpValue - onScreenDownValue; }
	}
	
	float ForwardDirection()
	{
		if(Input.GetKey(KeyCode.W))
		{
			return 1;
		}
		if(Input.GetKey(KeyCode.S))
		{
			return -1;
		}

		return OnScreenVertical;
	}
	
	float SidewaysDirection()
	{
		if(Input.GetKey(KeyCode.D))
		{
			return 1;
		}
		if(Input.GetKey(KeyCode.A))
		{
			return -1;
		}

		return OnScreenHorizontal;
	}
	
	bool IsRunning()
	{
		if(Input.GetKey(KeyCode.LeftShift))
		{
			return true;
		}

		return false;
	}
	
#endregion

#region Camera Stuff

	float RotationY()
	{
		return Mathf.Clamp(Input.GetAxis("Mouse X"),-1,1);
	}

	float TiltCamera()
	{
		return Mathf.Clamp(-Input.GetAxis("Mouse Y"), -1, 1);
	}
	

#endregion

#region Fishing Controls
private bool FireRay(out RaycastHit hit)
	{
		Debug.DrawRay(playerCamera.transform.position,playerCamera.transform.forward*maxFiringDistance,Color.red,1f);
		if(Physics.Raycast(playerCamera.transform.position,playerCamera.transform.forward,out hit, maxFiringDistance))
		{
			return true;
		}
		return false;

	}
void FireRod()
	{
		RaycastHit hit;
		if(!FireRay(out hit))
		{
			return;
		}
		Debug.Log(hit.transform.name);
		if(hit.transform.CompareTag("Fish"))
		{
			AddScore(hit.transform.GetComponent<Renderer>().material.color);
			hit.transform.gameObject.SetActive(false);
			//Destroy(hit.transform);
		}
		
	}
	
#endregion



#region Score Keeping

	void AddScore(Color _color)
	{
		fishScore++;
		fishText.text = fishScore.ToString();
		Debug.Log(_color);
	}
	

#endregion
	
}
