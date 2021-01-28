using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField ]Rigidbody rb;

	Vector3 moveDir;

	[SerializeField] float moveForce = 1000;

	public Vector3 flightDir;
	
	void Start()
	{
		
	}
	
	void Update()
	{
		// moveDir *= 0.9f;
	}

	void FixedUpdate()
	{
		MoveRb();
	}


	void MoveRb()
	{
		rb.AddForce( moveDir * (moveForce * Time.fixedDeltaTime) );
	}

	public void OnMove( InputValue value )
	{
		Vector2 inputDir = value.Get<Vector2>();

		flightDir = inputDir;
		
		moveDir = inputDir;
		
	}
}