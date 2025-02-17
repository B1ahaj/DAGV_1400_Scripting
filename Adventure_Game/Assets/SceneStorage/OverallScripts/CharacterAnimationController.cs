using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Update()
    {
        HandleAnimations();
    }
    
    private void HandleAnimations()
    {

        //Activates run animation
        bool isMoving = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0;
        {
            animator.SetBool("Run", isMoving);
        }
        
        //Activates jump animation
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
        }
        
        //Activates double jump animation
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("DoubleJump");
        }
        
        //Activates fall animation
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Fall");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        
        //Activates wall jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("WallJump");
        }
        
        //Activates hit animation
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("Hit");
        }
    }
}
