using UnityEngine;
public class ColorChange : MonoBehaviour
{
    private Renderer objRenderer;
    void Start()
    {
        // Gets the renderer component of the thing
        objRenderer = GetComponent<Renderer>();
    }
    void OnCollisionEnter(Collision collision)
    {
        // Changes the color when it initially collides with another thing
        objRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
    void OnCollisionExit(Collision collision)
    {
        // Changes the color again when it leaves
        objRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
