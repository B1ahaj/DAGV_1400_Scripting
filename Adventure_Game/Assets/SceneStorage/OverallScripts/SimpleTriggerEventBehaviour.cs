using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEventBehaviour : MonoBehaviour
{
    public UnityEvent triggerEvent;

    public void OnTriggerEnter(Collider other)
    {
        //trigger the event and test with a debug msg
        triggerEvent.Invoke();
        Debug.Log("player interacted with the object");
    }
}
