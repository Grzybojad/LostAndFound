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
	[SerializeField] float counterweightForce = 100;
	[SerializeField] float slowMultiplier = 0.5f;
	
	public Vector3 flightDir;
	bool slowActive;
	
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
		rb.AddForce( Vector3.up * (counterweightForce * Time.fixedDeltaTime), ForceMode.Acceleration );
		
		
		float movementForce = slowActive ? moveForce * slowMultiplier : moveForce;
		rb.AddForce( moveDir * (movementForce * Time.fixedDeltaTime), ForceMode.Acceleration );

		rb.velocity *= 0.999f;
	}

	public void OnMove( InputValue value )
	{
		Vector2 inputDir = value.Get<Vector2>();

		flightDir = inputDir;
		
		moveDir = inputDir;
	}

	public void OnSlow( InputValue value )
	{
		slowActive = value.Get<float>() > 0.5f;
	}

	void OnCollisionEnter( Collision other )
	{
		if( other.gameObject.CompareTag( "Chain" ) )
		{
			Physics.IgnoreCollision( other.gameObject.GetComponent<Collider>(), GetComponent<Collider>() );
		}
	}
}