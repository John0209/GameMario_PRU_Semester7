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
    bool m_turn = true;// quay đầu
    bool m_die=false;
    Rigidbody2D m_rgb;
    BoxCollider2D m_box;
    Henshin m_henshin;
    Vector2 locationDie;// vị trí lúc chết
    //---------------------------------------
    int m_score;// điểm ăn xu
    int m_star_henshin;// điểm ăn sao biến hình
    UIManager m_manager;
    public GameObject m_xu;
    public GameObject m_star;
    // Start is called before the first frame update
    void Start()
    {
        m_rgb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_henshin=FindObjectOfType<Henshin>();
        m_box= GetComponent<BoxCollider2D>();
        m_manager = FindObjectOfType<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetFloat("speed", speed);
        m_animator.SetBool("ground", ground);
        m_animator.SetBool("turn", turn);
        m_animator.SetBool("die", die);
        m_animator.SetBool("circle", circle);
        // call function
        Jumping();
        SpeedRun();
        Circle();
        EatStar(); // điều kiện biến hình
        // biến hình Hayyyyyoooooo
        if (henshin){

            switch (level){
                case 1:
                    StartCoroutine(m_henshin.Mario());
                    henshin = false;
                    break;
                case 2:
                    StartCoroutine(m_henshin.MarioGreen());
                    henshin = false;
                    break;
                case 3:
                    StartCoroutine(m_henshin.MarioPink());
                    henshin = false;
                    break;
            }
        }
    }
    private void FixedUpdate()
    {
        Moving();
    }
    // Set Điều kiện để henshin
    void EatStar()
    {
        if (m_star_henshin >= 1) m_manager.ActiveButtonLv2();
        if (m_star_henshin >= 2) m_manager.ActiveButtonLv3();
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
    }
    
    // lăn tròn tấn công
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
        //ăn xu
        if (col.gameObject.CompareTag("xu"))
        {
            m_xu.SetActive(false);
            m_score++;
            m_manager.SetTextScore("x 0" + m_score);
        }
        // ăn sao
        if (col.gameObject.CompareTag("star"))
        {
            m_star.SetActive(false);
            m_star_henshin++;
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
