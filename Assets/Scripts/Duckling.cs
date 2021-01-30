using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckling : MonoBehaviour
{
    bool dead;
    bool rescued;

    [SerializeField] AnimatingMaterial animatingMaterial;
    [SerializeField] Texture toastedTexture;
    [SerializeField] Texture squashedTexture;

    void OnTriggerEnter( Collider other )
    {
        if( dead || rescued ) return;
        
        if( other.CompareTag( "DeathZone" ) )
        {
            OnSquashed();
        }
        else if( other.CompareTag( "Fire" ) )
        {
            OnBurned();
        }

        if( other.CompareTag( "WinTrigger" ) )
        {
            OnRescued();
        }
    }

    void OnBurned()
    {
        animatingMaterial.SetTexture( toastedTexture );
        animatingMaterial.enabled = false;
        
        OnDeath();
    }

    void OnSquashed()
    {
        animatingMaterial.SetTexture( squashedTexture );
        animatingMaterial.enabled = false;
        
        OnDeath();
    }
    
    void OnDeath()
    {
        dead = true;

        GameManager.Instance.DucklingDied();
    }

    void OnRescued()
    {
        rescued = true;
        
        GameManager.Instance.DucklingRescued();
    }
}
