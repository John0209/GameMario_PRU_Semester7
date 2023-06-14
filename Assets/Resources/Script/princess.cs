using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class princess : MonoBehaviour
{
    princessReal m_princess;
    private void Start()
    {
        m_princess= FindObjectOfType<princessReal>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            m_princess.DisActiveTrigger();
        }
    }
}
