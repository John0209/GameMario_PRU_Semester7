using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MarioMove : MonoBehaviour
{
    #region animator
    Animator m_animator;
    float speed = 0;
    bool ground = true;
    bool turn = false;
    public bool die = false;// hoạt ảnh die
    public bool circle=false;
    #endregion animator
    //---------------------------------------
    public int level;
    public bool henshin=true;// biến bool dùng để active biến hình
    float speed_move=5f;// tốc độ chạy
    float jumped_move=450f;// lực nhảy
    float jumped_low=50f;// nhảy thấp
    float gravity=5f;// trọng lực
    bool m_turn = true;
    bool m_die=false;
    Rigidbody2D m_rgb;
    BoxCollider2D m_box;
    Henshin m_henshin;
    float late = 0.1f;
    Vector2 locationDie;// vị trí lúc chết

    // Start is called before the first frame update
    void Start()
    {
        m_rgb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_henshin=FindObjectOfType<Henshin>();
        m_box= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetFloat("speed", speed);
        m_animator.SetBool("ground", ground);
        m_animator.SetBool("turn", turn);
        m_animator.SetBool("die", die);
        m_animator.SetBool("circle", circle);
        Jumping();
        SpeedRun();
        Circle();
        // biến hình Hayyyyyoooooo
        if (henshin){

            switch (level){
                case 3:
                    StartCoroutine(m_henshin.Mario());
                    henshin = false;
                    break;
                case 1:
                    StartCoroutine(m_henshin.MarioPink());
                    henshin = false;
                    break;
                case 2:
                    StartCoroutine(m_henshin.MarioGreen());
                    henshin = false;
                    break;
            }
        }
    }
    public void ActiveMarioDie()
    {
        if (die)
        {
            locationDie = transform.localPosition;//vị trí chết
            StartCoroutine(MarioDie());
        }
    }
    IEnumerator MarioDie()
    {
        float jump_Die = 30f;
        bool is_Check = true;
        m_rgb.bodyType = RigidbodyType2D.Kinematic;
        while(true)
        {
            if (is_Check)
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + jump_Die * Time.deltaTime);

      if(transform.localPosition.y >= locationDie.y + 3)
                is_Check = false;
            yield return null;
            if (is_Check == false)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - jump_Die * Time.deltaTime);
            }
            if (transform.localPosition.y<=-6f)
            {
                Destroy(gameObject);
                break;
            }
            yield return null;
        }
       // Vector3 posY = transform.localPosition;
        
       // //vừa rơi xuống thì nhảy bật lên lại
       // if (!m_die) posY.y += 1 * Time.deltaTime *jump_Die;
       // // hủy nhân vật
       // if (posY.y < -3f && m_die)
       // {
       //    Destroy(gameObject);
       // }
       // //khi bật lên 1 ngưỡng nhất định thì rơi xuống lại
       // if ((posY.y < (locationDie.y + 4) || posY.y > (locationDie.y + 4)) && m_die)
       // {
       //     posY.y -= 1 * Time.deltaTime * jump_Die;
       // }
       // //nhảy lên tới 1 mức độ thì bắt đâu rơi xuống
       // if (posY.y >= (locationDie.y + 4)) m_die = true;
       // //cập nhật lại position y
       // transform.position = posY;
       // yield return null;
       //// StartCoroutine(MarioDie());

    }
    private void FixedUpdate()
    {
        Moving();
    }
    // bắn súng
    private void Circle()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            circle= true;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
           circle= false;
        }
    }
    //khi nhấn Shift để tăng tốc độ chạy
    private void SpeedRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed_move = 9f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed_move = 5f;
        }
    }
    private void Moving()
    {
        float right_left = Input.GetAxis("Horizontal");
        m_rgb.velocity=new Vector2(speed_move*right_left,m_rgb.velocity.y);
        speed=Mathf.Abs(speed_move * right_left);
        if (right_left > 0 && !m_turn) Scale();
        if (right_left < 0 && m_turn) Scale();
    }
    // dùng để đổi hoạt ảnh khi quay trái phải
    private void Scale()
    {
        Vector2 marioTurn = transform.localScale;
        marioTurn.x *= -1;
        //doi huong quay
        transform.localScale=marioTurn;
        //doi nguoc lai status m_turn
        m_turn = !m_turn;
        StartCoroutine(ChangePicture());
    }
    private void Jumping()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&ground)
        {
            m_rgb.AddForce((Vector2.up) * jumped_move);
            ground = false;
        }
        if (m_rgb.velocity.y < 0)
            m_rgb.velocity += Vector2.up * Physics2D.gravity.y * (gravity - 1) * Time.deltaTime;
        else if(m_rgb.velocity.y>0 && !Input.GetKey(KeyCode.Space))
            m_rgb.velocity += Vector2.up * Physics2D.gravity.y * (jumped_low - 1) * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            ground = true;
        }
        //mario die
        if (col.gameObject.CompareTag("underGround")||col.gameObject.CompareTag("enemies"))
        {
            m_box.isTrigger = true;
            die = true;
            ActiveMarioDie();

        }


    }
    // WaitForSecond để thay đỏi hoạt hình quay đầu
    IEnumerator ChangePicture()
    {
        turn = true;
        yield return new WaitForSeconds(0.2f);
        turn=false;
    }
    
    }
