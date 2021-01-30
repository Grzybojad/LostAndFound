using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Texture happyMom;
    [SerializeField] AnimatingMaterial duckMomAnimator;
    
    [Header("UI")]
    [SerializeField] GameObject winText;
    [SerializeField] RescueScoreText scoreText;
    
    int livingDucklings;
    int rescuedDucklings;
    
    void Start()
    {
        if( Instance != null )
        {
            Destroy( gameObject );
            return;
        }

        Instance = this;
        
        livingDucklings = GameObject.FindGameObjectsWithTag( "Duckling" ).Length;
        
        scoreText.SetToRescue( livingDucklings );
    }

    public void DucklingRescued()
    {
        rescuedDucklings++;

        scoreText.AddRescued();
        
        if( rescuedDucklings == livingDucklings )
        {
            OnWin();
        }
    }

    public void DucklingDied()
    {
        livingDucklings--;

        if( livingDucklings == 0 )
        {
            OnGameOver();
        }
    }

    void OnWin()
    {
        winText.SetActive( true );
        
        duckMomAnimator.SetTexture( happyMom );
        duckMomAnimator.enabled = false;
    }

    void OnGameOver()
    {
        Debug.Log( "Game over :(" );
    }
}
