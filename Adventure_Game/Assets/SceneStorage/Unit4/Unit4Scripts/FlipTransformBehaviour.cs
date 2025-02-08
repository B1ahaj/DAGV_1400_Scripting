using UnityEngine;

public class FlipTransformBehaviour : MonoBehaviour
{
    public float direction1 = 0f, direction2 = 180f;
    // rotation for right and left
    
    private float horizontalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        // gets horizontal input
        
        if (horizontalInput > 0) 
        // If moving right (positive (above 0) input) flips sprite
        {
            transform.rotation = Quaternion.Euler(x: 0, y: direction1, z: 0);
        }

        else if (horizontalInput < 0)
        // If moving left (negative (below 0) input) flips sprite
        {
            transform.rotation = Quaternion.Euler(x: 0, y: direction2, z: 0);
        }
    }
}
