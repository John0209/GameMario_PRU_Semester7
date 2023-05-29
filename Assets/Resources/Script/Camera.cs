using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform Player;
    private float minX = 0, maxX = 67.92f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            Vector3 m_position=transform.position;
            m_position.x=Player.position.x;
            //cho camera move theo vi tri character
            if(m_position.x > maxX) m_position.x = maxX;
            if(m_position.x < minX) m_position.x = minX;
            transform.position = m_position;
        }
    }
}
