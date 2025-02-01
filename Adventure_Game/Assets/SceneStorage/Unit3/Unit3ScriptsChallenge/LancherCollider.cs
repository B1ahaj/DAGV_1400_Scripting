using UnityEngine;
public class LancherCollider : MonoBehaviour
{
    public float bouncyPower = 4f;
    public float pauseAmount = 5f;
    
    private Rigidbody rb;
    private bool shouldBounce = false;
    private float bounceTimer = 0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        shouldBounce = true;
        bounceTimer = Time.time + pauseAmount;
    }

    private void Update()
    {
        if (shouldBounce && Time.time >= bounceTimer)
        {
            // Apply the boing force after the pause
            rb.AddForce(Vector3.up * bouncyPower, ForceMode.Impulse);
            // Reset the boing
            shouldBounce = false;
        }
    }
}
