using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enomies : MonoBehaviour
{
    public GameObject m_enomies;
    public GameObject m_itemStar;
    GameObject Mario;
    MarioMove m_mario;
    Rigidbody2D m_rgb;
    Vector2 locationDie;// vị trí lúc chết
    private void Start()
    {
        m_mario=FindObjectOfType<MarioMove>();
        Mario = GameObject.FindGameObjectWithTag("Player");
        m_rgb=GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player" && (m_mario.circle==true))
        {
            //Debug.Log(col.contacts[0].normal.x);// right -, left +
            if(col.contacts[0].normal.x<0)
                ActiveEnomyDie(false);
            else
                ActiveEnomyDie(true);
        }
        else if(col.collider.tag == "Player")
        {
            m_mario.die = true;
            Mario.GetComponent<MarioMove>().ActiveMarioDie();
        }
    }
    public void ActiveEnomyDie(bool is_turn)
    {
            locationDie = transform.localPosition;//vị trí chết
            StartCoroutine(EnomiesDie(is_turn));
    }
    IEnumerator EnomiesDie(bool is_turn)
    {
        float jump_Die = 12f;
       // bool is_Check = true;
        
        m_rgb.bodyType = RigidbodyType2D.Kinematic;
        while (true)
        {
            //xem thử đụng bên nào, bay bên đó
            if(!is_turn)
                m_enomies.transform.localPosition = new Vector2(m_enomies.transform.localPosition.x - jump_Die * Time.deltaTime, 
                    m_enomies.transform.localPosition.y + jump_Die * Time.deltaTime);
            else
                m_enomies.transform.localPosition = new Vector2(m_enomies.transform.localPosition.x + jump_Die * Time.deltaTime,
                   m_enomies.transform.localPosition.y + jump_Die * Time.deltaTime);
            //hủy enomy
            if (m_enomies.transform.localPosition.x <= locationDie.x - 4 || m_enomies.transform.localPosition.x >= locationDie.x + 4)
            {
                Destroy(gameObject);
                m_itemStar.SetActive(true);
                break;
            }
            m_itemStar.transform.localPosition = new Vector2(locationDie.x+2,locationDie.y);
            yield return null;
        }
    }
}
