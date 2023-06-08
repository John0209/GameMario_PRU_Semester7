using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    float speed_Move = 2;//toc do di chuyen của rùa
    bool turn_Left = true;
    private void FixedUpdate()
    {
        Vector2 FlyMove = transform.localPosition;

        if (turn_Left)
            FlyMove.x -= speed_Move * Time.deltaTime;
        else
            FlyMove.x += speed_Move * Time.deltaTime;
        //gắn lại position cho turtle
        if (FlyMove.x < 46.3f || FlyMove.x > 49.04f)
        {
            turn_Left = !turn_Left;
            //quay đầu
            Vector2 FlyTurn = transform.localScale;
            FlyTurn.x *= -1;
            transform.localScale = FlyTurn;
        }
        transform.localPosition = FlyMove;
    }
    
}
