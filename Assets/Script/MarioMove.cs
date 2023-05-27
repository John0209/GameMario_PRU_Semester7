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
    bool die = false;// hoạt ảnh die
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
    Henshin m_henshin;
    float late = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        m_rgb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_henshin=FindObjectOfType<Henshin>();
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetFloat("speed", speed);
        m_animator.SetBool("ground", ground);
        m_animator.SetBool("turn", turn);
        m_animator.SetBool("die", die);
        Jumping();
        SpeedRun();
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
            if (die) MarioDie();
    }
    private void MarioDie()
    {
        Vector3 posY = transform.position;
        if(!m_die) posY.y += 1;

        if (posY.y < -4f && m_die)
        {
           Destroy(gameObject);
        }
        if ((posY.y < 1.5f || posY.y > 1.5f) && m_die)
        {
            posY.y -= 1;
        }
        if (posY.y >= 1.5f) m_die = true;
        transform.position = posY;
        Debug.Log(posY.y);
       // StartCoroutine(MarioDie());

    }
    private void FixedUpdate()
    {
        Moving();
    }
    // khi nhấn Shift để tăng tốc độ chạy
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
        if (col.gameObject.CompareTag("underGround"))
        {
            die = true;
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
