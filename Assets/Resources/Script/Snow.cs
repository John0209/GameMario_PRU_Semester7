using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Snow : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("underGround"))
        {
            Destroy(gameObject);
        }
    }
}
