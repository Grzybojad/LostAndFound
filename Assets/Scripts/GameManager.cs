using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] PlayerController playerController;
    
    [Header("Duck mom")]
    [SerializeField] Texture happyMom;
    [SerializeField] AnimatingMaterial duckMomAnimator;
    
    [Header("UI")]
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    [SerializeField] RescueScoreText scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    
    int livingDucklings;
    int rescuedDucklings;
    float gameTime;

    bool gameOver;
    bool gameStarted;
    
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

    void Update()
    {
        if( !gameStarted )
        {
            if( Keyboard.current.anyKey.wasPressedThisFrame )
            {
                gameStarted = true;
            }
            
            return;
        }
        
        if( Keyboard.current.rKey.wasPressedThisFrame )
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
        }
        
        if( Keyboard.current.escapeKey.wasPressedThisFrame )
        {
            Application.Quit();
        }

        if( !gameOver )
        {
            gameTime += Time.deltaTime;

            string seconds = $"{gameTime:n0}";
            seconds = seconds.PadLeft( 2, '0' );
            
            string hundreds = $"{( gameTime * 1000 % 1000 ):n0}";
            hundreds = hundreds.PadLeft( 3, '0' );

            timeText.text = $"{seconds}:{hundreds}";
        }
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
        else if( rescuedDucklings == livingDucklings )
        {
            OnWin();
        }
    }

    void OnWin()
    {
        winText.SetActive( true );
        
        duckMomAnimator.SetTexture( happyMom );
        duckMomAnimator.enabled = false;
        
        playerController.OnWin();

        gameOver = true;
    }

    void OnGameOver()
    {
        loseText.SetActive( true );
        
        playerController.OnLose();

        gameOver = true;
    }
}
