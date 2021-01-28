using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	Rigidbody rb;

	Vector3 moveDir;
	Quaternion targetRot;

	[SerializeField] float moveForce = 1000;
	[SerializeField] float maxAngle = 100;
	[SerializeField] float rotationTime = 0.5f;

	float rotationVelocity;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();

		targetRot = transform.rotation;
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
		rb.MoveRotation( targetRot );
	}

	public void OnMove( InputValue value )
	{
		Vector2 inputDir = value.Get<Vector2>();
		// Quaternion rot = transform.rotation;

		moveDir = inputDir;

		// moveDir = (transform.up * inputDir.y).normalized;
		//
		// float currentAngle = rot.eulerAngles.z;
		// float targetAngle = inputDir.x * maxAngle;
		// float newAngle = Mathf.SmoothDampAngle( currentAngle, targetAngle, ref rotationVelocity, rotationTime );
		//
		// Debug.Log( targetAngle );
		//
		// targetRot = Quaternion.Euler( rot.x, rot.y, newAngle );
	}
}