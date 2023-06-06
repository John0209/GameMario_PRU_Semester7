using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enomies : MonoBehaviour
{
   GameObject Mario;
    MarioMove m_mario;
    private void Start()
    {
        m_mario=FindObjectOfType<MarioMove>();
        Mario = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player" && (m_mario.circle==true))
        {
            Debug.Log("y");
        }
        else if(col.collider.tag == "Player")
        {
            m_mario.die = true;
            Mario.GetComponent<MarioMove>().ActiveMarioDie();
        }
    }
}
