using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    float speed_Move=2;//toc do di chuyen của rùa
    bool turn_Left = true;
  
    private void FixedUpdate()
    {
        Vector2 TurtleMove =transform.position;
        if (turn_Left) {
            TurtleMove.x -= speed_Move * Time.deltaTime;
        }
        else
        {
            TurtleMove.x += speed_Move * Time.deltaTime;
        }
        //gắn lại position cho turtle
        transform.position = TurtleMove;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("limit"))
        {
            turn_Left = !turn_Left;
            //quay đầu
            Vector2 TurtleTurn = transform.localScale;
            TurtleTurn.x *= -1;
            transform.localScale = TurtleTurn;
        }
    }
}
