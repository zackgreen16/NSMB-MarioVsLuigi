using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliseUI : MonoBehaviour
{
    TextMeshProUGUI textField;

    public string key;

    // Start is called before first frame update
    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        string value = LocalisationSystem.GetLocalisedValue(key);
        textField.text = value;
    }
}
