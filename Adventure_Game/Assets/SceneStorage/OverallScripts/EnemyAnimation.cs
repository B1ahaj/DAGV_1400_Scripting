using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private NavMeshAgent agent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check if the creature is moving
        if (agent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("isRunning", true);

            // Flip the sprite based on the movement direction
            if (agent.velocity.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (agent.velocity.x > 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}

