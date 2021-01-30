using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatingMaterial : MonoBehaviour
{
    Renderer rend;
    [SerializeField] Texture[] textures;
    [SerializeField] float framesPerSecond;

    int activeFrame;
    float currentFrameTime;

    void Start()
    {
        rend = GetComponent<Renderer>();
        currentFrameTime = Random.Range( 0f, 1 / framesPerSecond );
    }
    
    void Update()
    {
        currentFrameTime += Time.deltaTime;

        if( currentFrameTime > ( 1 / framesPerSecond ) )
        {
            currentFrameTime = 0;
            activeFrame++;

            activeFrame %= textures.Length;
            
            rend.material.mainTexture = textures[ activeFrame ];
        }
    }

    public void SetTexture( Texture texture )
    {
        rend.material.mainTexture = texture;
    }
}
