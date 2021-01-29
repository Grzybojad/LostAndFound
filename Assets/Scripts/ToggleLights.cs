using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLights : MonoBehaviour
{
    [SerializeField] Renderer rend;
    [SerializeField] PlayerController playerController;
    
    Material leftLights;
    Material rightLights;

    void Start()
    {
	    Material[] materials = rend.materials;

	    for( int i = 0; i < materials.Length; i++ )
	    {
		    if( materials[ i ].name == "Drone Light Right (Instance)" )
		    {
			    Material newMaterial = new Material( materials[ i ].shader );
			    newMaterial.CopyPropertiesFromMaterial( materials[ i ] );
			    
			    materials[ i ] = newMaterial;
			    leftLights = materials[ i ];
		    }
		    else if( materials[ i ].name == "Drone Light Left (Instance)" )
		    {
			    Material newMaterial = new Material( materials[ i ].shader );
			    newMaterial.CopyPropertiesFromMaterial( materials[ i ] );

			    newMaterial.SetFloat( "_EmissionStrength", 0 );
			    
			    materials[ i ] = newMaterial;
			    rightLights = materials[ i ];
		    }
	    }

	    rend.materials = materials;
    }

    // Update is called once per frame
    void Update()
    {
	    float rightLightsStrength = Mathf.Clamp( -playerController.flightDir.x, 0, 1 );
	    float leftLightsStrength = Mathf.Clamp( playerController.flightDir.x, 0, 1 );

	    rightLights.SetFloat( "_EmissionStrength", rightLightsStrength );
	    leftLights.SetFloat( "_EmissionStrength", leftLightsStrength );
    }
}
