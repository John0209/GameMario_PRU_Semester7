using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    float speed_Move=2;//toc do di chuyen của rùa
    bool turn_Left = true;
    private void FixedUpdate()
    {
        Vector2 TurtleMove = transform.localPosition;
        Vector2 TurtleTurn = transform.localScale;
        if (turn_Left) {
            TurtleMove.x -= speed_Move * Time.deltaTime;
        }
        else
        {
            TurtleMove.x += speed_Move * Time.deltaTime;
        }
        if(TurtleMove.x < 18f || TurtleMove.x >22)
        {
            turn_Left = !turn_Left;
            TurtleTurn.x *= -1;
        }
        //gắn lại position cho turtle
        transform.localScale = TurtleTurn;
        transform.localPosition = TurtleMove;
    }

}
