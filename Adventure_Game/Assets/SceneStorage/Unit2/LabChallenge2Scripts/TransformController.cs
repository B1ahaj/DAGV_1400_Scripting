using UnityEngine;

public class TransformController : MonoBehaviour
{
    private void Update()
    {
        // Move the target GameObject   
        var x = Mathf.PingPong(Time.time, 5);
        var z = Mathf.PingPong(Time.time, 5);
        var y = Mathf.PingPong(Time.time, 1);
        transform.position = new Vector3(x, y, z);
        
        // Rotate the target GameObject
        transform.Rotate(new Vector3(190, 90, 0) * Time.deltaTime);
        
    }
}















