using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class princessReal : MonoBehaviour
{
    PolygonCollider2D m_rgb;
    private void Start()
    {
        m_rgb = GetComponent<PolygonCollider2D>();
    }
    public void DisActiveTrigger()
    {
        m_rgb.isTrigger = false;
    }
}
