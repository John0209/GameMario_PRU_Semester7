using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3 : MonoBehaviour
{
    private Transform Player;
    private float minX = 0, maxX = 120f;
    float minY = 0f, maxY = 10.11f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            Vector3 m_position = transform.position;
            m_position.x = Player.position.x;
            m_position.y = Player.position.y;
            //cho camera move theo vi tri character
            if (m_position.x > maxX) m_position.x = maxX;
            if (m_position.x < minX) m_position.x = minX;
            if (m_position.y < minY) m_position.y = minY;
           // if (m_position.y > maxY) m_position.y = maxY;
            if (m_position.y >6.8f ) m_position.y = maxY;
            transform.position = m_position;
        }
    }
}
