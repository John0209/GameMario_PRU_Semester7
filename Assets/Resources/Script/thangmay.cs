using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thangmay : MonoBehaviour
{
   
    float speed_Move = 3;//toc do di chuyen của rùa
    bool sau_Left = true;

    private void FixedUpdate()
    {
        Vector2 TurtleMove = transform.position;
        if (sau_Left)
        {
            TurtleMove.y -= speed_Move * Time.deltaTime;
        }
        else
        {
            TurtleMove.y += speed_Move * Time.deltaTime;
        }
        //gắn lại position cho turtle
        transform.position = TurtleMove;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("limit"))
        {
            sau_Left = !sau_Left;
        }
    }
}
