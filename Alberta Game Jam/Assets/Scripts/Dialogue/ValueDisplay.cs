using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValueDisplay : MonoBehaviour
{
    public string prefix;
    public string suffix;
    public float value;

    private TextMeshProUGUI m_TextMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        m_TextMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_TextMeshPro.text = $"{prefix} {value} {suffix}";
    }
}
