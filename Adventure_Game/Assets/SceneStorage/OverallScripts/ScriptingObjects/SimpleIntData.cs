using UnityEngine;

[CreateAssetMenu(menuName = "SingleVariables/SimpleIntData")]
public class SimpleIntData : ScriptableObject
{
    public int value;
    
    public void UpdateValue(int amount)
    {
        value += amount;
    }

    public void SetValue(int amount)
    {
        value = amount;        
    }
}
