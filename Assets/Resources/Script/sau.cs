using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sau : MonoBehaviour
{
    float speed_Move = 2;//toc do di chuyen của rùa
    bool sau_Left = true;

    private void FixedUpdate()
    {
        Vector2 TurtleMove = transform.position;
        if (sau_Left)
        {
            TurtleMove.x -= speed_Move * Time.deltaTime;
        }
        else
        {
            TurtleMove.x += speed_Move * Time.deltaTime;
        }
        //gắn lại position cho turtle
        transform.position = TurtleMove;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("alo");
        if (col.gameObject.CompareTag("limit"))
        {
            sau_Left = !sau_Left;
            //quay đầu
            Vector2 TurtleTurn = transform.localScale;
            TurtleTurn.x *= -1;
            transform.localScale = TurtleTurn;
        }
    }

}
