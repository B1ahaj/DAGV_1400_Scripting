using UnityEngine;
using UnityEngine.Events;

public class AnimationHashDetection : MonoBehaviour
{
    public Animator animator;
    public UnityEvent onTargetAnimationPlayed;

    private int targetAnimationHash;
    
    // Tracks whether the event has already activated
    private bool hasTriggered = false;
    
    void Start()
    {
        targetAnimationHash = Animator.StringToHash("Jump");
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == targetAnimationHash)
        {
            if (!hasTriggered) 
                // activate event only if it hasn't been triggered yet
            {
                onTargetAnimationPlayed.Invoke();
                hasTriggered = true;
            }
        }
        else 
        { 
            hasTriggered = false; 
            // Reset when animation is no longer playing
        }
    }
}
