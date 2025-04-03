using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Util/Removal Util")]
public class SimpleRemover: ScriptableObject
{
    public void Destroyer(GameObject gameObject)
    {
        Object.Destroy(gameObject);
    }
}
