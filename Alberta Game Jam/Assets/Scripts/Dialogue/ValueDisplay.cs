using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class ValueDisplay : MonoBehaviour
{
    [TextArea]
    public string prefix;
    [TextArea]
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
        m_TextMeshPro = m_TextMeshPro != null ? m_TextMeshPro : GetComponent<TextMeshProUGUI>();
        m_TextMeshPro.text = prefix + value + suffix;
    }
}
