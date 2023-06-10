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
    public bool hp = false;
    public bool fly = false;
    public bool shoot=false;
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
    public GameObject m_shoot;
    public Transform m_transform;
    Rigidbody2D m_rgb;
    BoxCollider2D m_box;
    Henshin m_henshin;
    Vector2 locationDie;// vị trí lúc chết
    bool isMark = true; // check để tắt fly
    //---------------------------------------
    int m_score;// điểm ăn xu
    public int m_star_henshin;// điểm ăn sao biến hình
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
        m_animator.SetBool("hp", hp);
        m_animator.SetBool("fly", fly);
        m_animator.SetBool("shoot", shoot);
        // call function
        Moving();
        Jumping();
        SpeedRun();
        Skill();
        EatStar(); // điều kiện biến hình
        if (fly) Flight(); // điều khiển mario khi bay
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
    

    #region Die
    // Nếu đụng trúng enomy, sẽ trừ sao hạ cấp
    public void MinusStar()
    {
        if (m_star_henshin < 2)
        {
            henshin = true;
            level = 1;
            m_manager.DisActiveButtonLv2();
        }
        if (m_star_henshin < 3)
        {
            henshin = true;
            level = 2;
            m_manager.DisActiveButtonLv3();
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
    }
    #endregion

    #region WaitSecond
    // WaitForSecond để thay đỏi hoạt hình quay đầu
    IEnumerator ChangePicture()
    {
        turn = true;
        yield return new WaitForSeconds(0.2f);
        turn = false;
    }
    // check hết 3s sẽ tự hạ xuống đất
    IEnumerator DisFly()
    {
        isMark = false;
        yield return new WaitForSeconds(3);
        m_rgb.bodyType = RigidbodyType2D.Dynamic;
        fly = false;
        isMark = true;
    }
    IEnumerator DisCirle()
    {
        isMark = false;
        yield return new WaitForSeconds(3);
        circle = false;
        isMark = true;
    }
    #endregion

    #region Điều Kiện
    // Set Điều kiện để henshin
    void EatStar()
    {
        if (m_star_henshin == 2) m_manager.ActiveButtonLv2();
        if (m_star_henshin == 3) m_manager.ActiveButtonLv3();
    }
    // lăn tròn tấn công
    private void Skill()
    {
        // Red Circle
        if (Input.GetKey(KeyCode.R) && level==1)
        {
            circle= true;
            if (isMark) StartCoroutine(DisCirle());
        }
        // Green fly
        if (Input.GetKey(KeyCode.R) && level == 2)
        {
            m_rgb.bodyType = RigidbodyType2D.Kinematic; 
            fly = true;
            Flight();
          if(isMark) StartCoroutine(DisFly());
        }
        if (Input.GetKeyDown(KeyCode.R) && level == 3 && speed==0)
        {
            shoot = true;
            PinkShoot();
        }
        if (Input.GetKeyUp(KeyCode.R) && level == 3 && speed == 0)
        {
            shoot = false;
        }

    }
    #endregion

    #region Action
    // hồng bắn đạn
    public void PinkShoot()
    {
        m_shoot.SetActive(true);
        Instantiate(m_shoot,m_transform.position,Quaternion.identity);
    }
    // Action bay và chạy
    private void Flight()
    {
        float right_left = Input.GetAxis("Horizontal");
        float fly = Input.GetAxis("Vertical");
        m_rgb.velocity = new Vector2(speed_move * right_left,fly* speed_move);
    }
    private void Moving()
    {
        float right_left = Input.GetAxis("Horizontal");
        m_rgb.velocity=new Vector2(speed_move*right_left,m_rgb.velocity.y);
        speed =Mathf.Abs(speed_move * right_left);
        if (right_left > 0 && !m_turn) Scale();
        if (right_left < 0 && m_turn) Scale();
    }
    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            m_rgb.AddForce((Vector2.up) * jumped_move);
            ground = false;
        }
        if (m_rgb.velocity.y < 0)
            m_rgb.velocity += Vector2.up * Physics2D.gravity.y * (gravity - 1) * Time.deltaTime;
        else if (m_rgb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            m_rgb.velocity += Vector2.up * Physics2D.gravity.y * (jumped_low - 1) * Time.deltaTime;
    }
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
    private void Scale()  // dùng để đổi hoạt ảnh khi quay trái phải
    {
        Vector2 marioTurn = transform.localScale;
        marioTurn.x *= -1;
        //doi huong quay
        transform.localScale = marioTurn;
        //doi nguoc lai status m_turn
        m_turn = !m_turn;
        StartCoroutine(ChangePicture());
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground"))// đứng trên đất
        {
            ground = true;
        }
        if (col.gameObject.CompareTag("underGround"))//mario die
        {
            m_box.isTrigger = true;
            die = true;
            ActiveMarioDie();
        }
        if (col.gameObject.CompareTag("xu"))//ăn xu
        {
            m_xu.SetActive(false);
            m_score++;
            m_manager.SetTextScore("x 0" + m_score);
        }
        if (col.gameObject.CompareTag("star")) // ăn sao
        {
            m_star.SetActive(false);
            m_star_henshin++;
            m_manager.SetTextStar("x 0" + m_star_henshin);
        }
    }
    
    }
