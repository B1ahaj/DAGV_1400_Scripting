using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEventBehaviour : MonoBehaviour

{
    public UnityEvent triggerEvent;

    public void OnTriggerEnter(Collider other)
    {
        triggerEvent.Invoke();
        Debug.Log("Hit the spike");
    }
}
