using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject mario;
    float speed = 5;
    float timeDestroy = 4;
    Rigidbody2D m_rgb;
    bool is_mark = true;
    void Start()
    {
        m_rgb = GetComponent<Rigidbody2D>();
       // Destroy(gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        if(mario.transform.localScale.x > 0 && is_mark)
        {
            m_rgb.velocity = Vector2.right * speed;
            is_mark = false;
        }
        if (mario.transform.localScale.x < 0 && is_mark)
        {
            m_rgb.velocity = Vector2.left * speed;
            is_mark = false;
        }
        //new Vector2(speed * right_left, m_rgb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemies"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ground") || col.gameObject.CompareTag("enemies"))
        {
            Destroy(gameObject);
        }
    }
}
