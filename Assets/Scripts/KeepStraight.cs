using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KeepStraight : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] PlayerController playerController;
    [SerializeField] float sideFlightAngle = 30f;
    
    [Header("Correction settings")]
    [SerializeField] float minCorrectionForce = 50;
    [SerializeField] float maxCorrectionForce = 100;
    [SerializeField] float deadzone = .1f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        float angle = rb.rotation.eulerAngles.z;

        if( angle > 180f )
            angle = -(360f - angle);

        float tAngle = -playerController.flightDir.x;
        float targetAngle = sideFlightAngle * tAngle;
        
        float t = Mathf.InverseLerp( 0f, 180f, Mathf.Abs( targetAngle - angle ) );
        float torqueToAdd = Mathf.Lerp( minCorrectionForce, maxCorrectionForce, t );
        
        
        if( angle > targetAngle + deadzone )
        {
            rb.AddTorque( 0, 0, -torqueToAdd * Time.fixedDeltaTime );
        }
        else if( angle < targetAngle - deadzone )
        {
            rb.AddTorque( 0, 0, torqueToAdd * Time.fixedDeltaTime );
        }

        rb.angularVelocity *= .9f;
    }
}
