using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f; 
    // How far up and down it moves
    public float moveSpeed = 2f;    
    // How fast it moves

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        // Ping-pong movement over time, smooth and infinite
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = startPos + Vector3.up * offset;
    }
}

