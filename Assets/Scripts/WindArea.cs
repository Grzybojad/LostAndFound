using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    [SerializeField] float strength = 1000;
    [SerializeField] Vector3 direction = Vector3.up;

    readonly Dictionary<int, int> collidersInArea = new Dictionary<int, int>();                  // collider id, rigidbody id
    readonly Dictionary<int, Rigidbody> rigidbodiesInArea = new Dictionary<int, Rigidbody>();

    void FixedUpdate()
    {
        // Add wind force to every rigidbody in area
        foreach( Rigidbody rb in rigidbodiesInArea.Values )
        {
            rb.AddForce( direction * (strength * Time.fixedDeltaTime), ForceMode.Acceleration );
        }
    }

    void OnTriggerEnter( Collider other )
    {
        Rigidbody rb = other.attachedRigidbody;
        if( rb == null ) return;

        int colliderId = other.GetInstanceID();
        int rbId = rb.GetInstanceID();

        if( collidersInArea.ContainsKey( colliderId ) ) return;
        
        collidersInArea.Add( colliderId, rbId );

        if( !rigidbodiesInArea.ContainsKey( rbId ) )
        {
            rigidbodiesInArea[ rbId ] = rb;
        }
    }

    void OnTriggerExit( Collider other )
    {
        Rigidbody rb = other.attachedRigidbody;
        if( rb == null ) return;
        
        int colliderId = other.GetInstanceID();
        int rbId = rb.GetInstanceID();
        
        collidersInArea.Remove( colliderId );

        // Check if there are still other colliders of the same rigidbody
        if( collidersInArea.ContainsValue( rbId ) || !rigidbodiesInArea.ContainsKey( rbId ) ) return;

        rigidbodiesInArea.Remove( rbId );
        Debug.Log( $"Removed rb {rbId}" );
    }
}
