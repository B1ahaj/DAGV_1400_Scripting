using UnityEngine;

public class BounceCollider : MonoBehaviour
{
    public float bounceForce = 3f; 
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
    }
}
