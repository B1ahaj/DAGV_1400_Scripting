using System;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SimpleTextMeshProGUI : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    public SimpleIntData dataObj;

    private void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        UpdateWithIntData();
    }

    public void UpdateWithIntData()
    {
        textObj.text = "Score: " + dataObj.value.ToString(CultureInfo.InvariantCulture);
    }
    public void Update()
    {
        UpdateWithIntData();
    }
}
