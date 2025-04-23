using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 2f;
    public float gravity = -20f;
    public int maxJumps = 2;
    private int currentJumps;

    public SimpleFloatData StaminaData;
    public float maxStamina = 1f;
    public float staminaRegenRate = 0.2f;

    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
        currentJumps = maxJumps; 
    }

    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
        JumpMovement();
        RegenerateStamina();
    }
    
    public void ResetVelocity()
    {
        velocity = Vector3.zero;
    }
    
    private void MoveCharacter()
    {
        // Horizontal movement
        var moveInput = Input.GetAxis("Horizontal");
        var move = new Vector3(moveInput, 0f, 0f) * (moveSpeed * Time.deltaTime);
        controller.Move(move);
    }

    private void JumpMovement()
    {
        // Jumping
        if (Input.GetButtonDown("Jump")&& currentJumps > 0) //&& controller.isGrounded) *this completely screws up jumping
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            currentJumps--;
        }
    }
    
    private void RegenerateStamina()
    {
        if (controller.isGrounded && StaminaData.value < maxStamina)
        {
            StaminaData.value += staminaRegenRate * Time.deltaTime;
            StaminaData.value = Mathf.Min(StaminaData.value, maxStamina); // Clamp to max
        }
    }
    
    private void ApplyGravity()
    {
        // Apply gravity when not grounded
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            if (velocity.y < 0f) velocity.y = 0f;
            // Reset velocity when grounded
            
            // Reset jumps when grounded
            currentJumps = maxJumps;
        }

        // Apply the velocity to the controller
        controller.Move(velocity * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        // Maintain character on the same z-axis position
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }
}
