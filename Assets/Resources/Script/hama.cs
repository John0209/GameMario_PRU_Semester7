using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hama : MonoBehaviour
{
    public GameObject m_enomies;
    public GameObject m_itemStar;
    public GameObject hamaphunlua;
    GameObject Mario;
    MarioMove m_mario;
    Rigidbody2D m_rgb;
    UIManager m_uiManager;
    Vector2 locationDie;// vị trí lúc chết
    private void Start()
    {
        m_mario = FindObjectOfType<MarioMove>();
        Mario = GameObject.FindGameObjectWithTag("Player");
        m_rgb = GetComponent<Rigidbody2D>();
        m_uiManager = FindObjectOfType<UIManager>();
    }
    private void OnTriggerEnter2D(Collider2D cols)
    {
        if (cols.gameObject.CompareTag("shoot"))
        {

            //    ActiveEnomyDie(false);
            //else
            ActiveEnomyDie(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {

        if ((col.collider.tag == "Player" && (m_mario.circle == true)) || col.collider.tag == "shoot")
        {
            //Debug.Log(col.contacts[0].normal.x);// right -, left +
            if (col.contacts[0].normal.x < 0)
                ActiveEnomyDie(false);
            else
                ActiveEnomyDie(true);
        }
        else if (col.collider.tag == "Player")
        {
            if (m_mario.m_star_henshin <= 1)
            {
                m_mario.die = true;
                Mario.GetComponent<MarioMove>().ActiveMarioDie();
            }
            else
            {
                StartCoroutine(MinusHp());
                m_mario.m_star_henshin--;
                m_uiManager.SetTextStar("x 0" + m_mario.m_star_henshin);
                m_mario.MinusStar();
            }

        }
    }
    IEnumerator MinusHp()
    {
        m_mario.hp = true;
        yield return new WaitForSeconds(0.3f);
        m_mario.hp = false;
    }
    public void ActiveEnomyDie(bool is_turn)
    {
        locationDie = m_enomies.transform.localPosition;//vị trí chết

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
            if (!is_turn)
                m_enomies.transform.localPosition = new Vector2(m_enomies.transform.localPosition.x - jump_Die * Time.deltaTime,
                    m_enomies.transform.localPosition.y + jump_Die * Time.deltaTime);
            else
                m_enomies.transform.localPosition = new Vector2(m_enomies.transform.localPosition.x + jump_Die * Time.deltaTime,
                   m_enomies.transform.localPosition.y + jump_Die * Time.deltaTime);
            //hủy enomy
            if (m_enomies.transform.localPosition.x <= locationDie.x - 4 || m_enomies.transform.localPosition.x >= locationDie.x + 4)
            {
                Destroy(hamaphunlua);
                Destroy(gameObject);
                m_itemStar.SetActive(true);
                break;
            }
            m_itemStar.transform.localPosition = new Vector2(locationDie.x + 1, locationDie.y + 0.5f);
            yield return null;
        }
    }
}
