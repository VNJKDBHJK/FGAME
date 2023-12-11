using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class qwe : MonoBehaviour
{
    public static qwe Instance;

    private Rigidbody2D rb;
    private Collider2D coll;
    public Animator anim;
    public float speed;
    public float jumpforce;
    public LayerMask ground;
    public PlayerHealth ph;

    // private bool jump;
    public int jumpcount = 2;
    private bool isjump = false;
    //public int carrot;
    public int Star;
    public float health = 0f;

    private Color color1 = new Color(119, 231, 231, 255);
    private Color color2 = new Color(195, 45, 40, 255);
    private Color color3 = new Color(0, 0, 0, 0);

    public Text carrotText;

    public bool ATTACK_01;
    public bool ATTACK_02;
    public bool ATTACK_05;
    public bool ATTACK_06;
    public int count_1=2;
    public int count_2 = 2;
    public int lock_key = 2;
    public bool lock_key_01;
    public bool lock_key_02;
    private void Awake()
    {
        Instance = this;  
    }

    void Start()
    {
        ph = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        carrotText .text= STATIC.carrot.ToString();//转化为字符串
        Jump();
        if (coll.IsTouchingLayers(ground) && isjump == false)
        {
            jumpcount = 2;
        }
        if(STATIC.carrot <= 0)
        {
            STATIC.carrot = 0;
        }
        if (STATIC.health >= 100)
        {
            STATIC.health = 100;
        }
        Crouch();
        Dash();
        Attack01();
        Attack02();
        Attack03();
        Attack04();
        Attack05();
        Attack06();
    }

    void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        //使得移动在-1,1之间,改变人物面向方向
        float Horizontalmove = Input.GetAxis("Horizontal");
        float FaceDirection = Input.GetAxisRaw("Horizontal");
        //移动
        if (Horizontalmove != 0)
        {
            rb.velocity = new Vector2(Horizontalmove * speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        //转换方向
        anim.SetFloat("run", Mathf.Abs(FaceDirection));
        if (FaceDirection != 0)
        {
            transform.localScale = new Vector3(FaceDirection, 1, 1);
        }
    }
    //跳跃
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpcount >= 0)
        {
            if (jumpcount == 2)
            {
                jumpcount--;
                rb.velocity = new(rb.velocity.x, jumpforce);
                if (rb.velocity.y >= 0)
                {
                    anim.SetBool("jump", true);
                }
            }
            else if (jumpcount == 1)
            {
                rb.velocity = new(rb.velocity.x, jumpforce);
                anim.SetBool("jump", false);
                anim.SetBool("frontflip", true);
                jumpcount--;
            }
            else if (jumpcount == 0)
            {
                anim.SetBool("frontflip", false);
                anim.SetBool("idle", true);

            }
        }
        if (rb.velocity.y < 3f && rb.velocity.y >= 0 && jumpcount == 1)
        {
            anim.SetBool("jump", false);
            anim.SetBool("jump1", true);
        }
        if (rb.velocity.y < -0.1f)
        {
            anim.SetBool("jump1", false);
            anim.SetBool("jump2", true);
            anim.SetBool("frontflip", false);
        }
        else if (rb.velocity.y > 0)
        {
            anim.SetBool("jump2", false);
            anim.SetBool("idle", true);
            isjump = true;
        }
        else
        {
            anim.SetBool("jump2", false);
            anim.SetBool("frontflip", false);
            isjump = false;
        }
    }
    //爬行
    void Crouch()
    {
        if (Input.GetButton("Crouch") && coll.IsTouchingLayers(ground))
        {
            anim.SetBool("crouch", true);
            anim.SetBool("crawl", false);
        }
        if (Input.GetButtonDown("Stopcrouch"))
        {
            anim.SetBool("crouch", false);
            anim.SetBool("idle", true);
        }
    }
    //冲刺
    void Dash()
    {
        if (Input.GetButton("Dash") && coll.IsTouchingLayers(ground))
        {
            anim.SetBool("dash", true);
            speed = 600f;
        }
        else
        {
            anim.SetBool("dash", false);
            speed = 380f;
        }
    }
    void Attack01()
    {
            if (Input.GetButtonDown("Attack01") && coll.IsTouchingLayers(ground) && STATIC.carrot > 0&&ATTACK_01)
            {
                anim.SetBool("attack01", true);
                STATIC.carrot -= 2;
            }
            else
            {
                anim.SetBool("attack01", false);
            }

    }
    void Attack02()
    {

            if (Input.GetButtonDown("Attack02") && coll.IsTouchingLayers(ground)&&STATIC.carrot>0&&ATTACK_02)
            {
                anim.SetBool("attack02", true);
                STATIC.carrot -= 4;
            }
            else
            {
                anim.SetBool("attack02", false);
            }
    }
    void Attack03()
    {
            if (Input.GetButtonDown("Attack03") && coll.IsTouchingLayers(ground)&&STATIC.carrot>0)
            {
                anim.SetBool("attack03", true);
                STATIC.carrot -= 1;
            }
            else
            {
                anim.SetBool("attack03", false);
            }
    }
    void Attack04()
    {
            if (Input.GetButtonDown("Attack04") && coll.IsTouchingLayers(ground)&&STATIC.carrot>0)
            {
                anim.SetBool("attack04", true);
               STATIC. carrot -= 1;
            }
            else
            {
                anim.SetBool("attack04", false);
            }
    }
    void Attack05()
    {
            if (Input.GetButtonDown("Attack05") && coll.IsTouchingLayers(ground)&&STATIC.carrot>0)
            {
                anim.SetBool("attack05", true);
                STATIC.carrot -= 3;
            }
            else
            {
                anim.SetBool("attack05", false);
            }
    }
    void Attack06()
    {
            if (Input.GetButtonDown("Attack06") && coll.IsTouchingLayers(ground)&&STATIC.carrot>0)
            {
                anim.SetBool("attack06", true);
                STATIC.carrot -= 6;
            }
            else
            {
                anim.SetBool("attack06", false);
            }
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "collection_carrot")
        {
            Destroy(collision.gameObject);
            STATIC.carrot += 1;
        }
        if (collision.tag == "collection_star")
        {
            Destroy(collision.gameObject);
            STATIC.health += 3;
        }
        if (collision.tag == "lookup")
        {
            anim.SetBool("lookup", true);
            anim.SetBool("idle", false);
        }
        else
        {
            anim.SetBool("lookup", false);
            anim.SetBool("idle", true);
        }
        if (collision.tag == "dead_line")
        {
            Invoke("Restart", 2f);
            STATIC.count--;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "lookup")
        {
            anim.SetBool("lookup", false);
            anim.SetBool("idle", true);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//重置当前场景,找到当前场景的名字
    }

    private void Destroy1()
    {
       // var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        if (ph.isdead)
        {
        SceneManager.LoadScene("gameover");

        }
    }
}
