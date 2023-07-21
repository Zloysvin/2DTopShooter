using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    private RectTransform m_RectTransform;
    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();

        // Hides the cursor...
        Cursor.visible = false;
    }
    void Update()
    {
        m_RectTransform.position = Input.mousePosition;
    }
}
