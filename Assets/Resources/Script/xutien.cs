using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xutien : MonoBehaviour
{
    UIManager m_manager;
    MarioMove marioMove;
    // Start is called before the first frame update
    void Start()
    {
        m_manager = FindObjectOfType<UIManager>();
        marioMove= FindObjectOfType<MarioMove>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))//ăn xu
        {
           
            Destroy(gameObject);
            marioMove.m_score+=2;
            m_manager.SetTextScore("x 0" + marioMove.m_score);
        }
    }
}
