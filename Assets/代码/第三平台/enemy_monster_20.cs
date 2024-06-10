using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_monster_20 : MonoBehaviour
{
    private Vector3 target;
    public Transform first_point, last_point;
    public Transform first_change_to_point;
    public GameObject bloodEffect;

    public float Speed;
    public int damage;
    protected Rigidbody2D rb;
    protected Collider2D coll;
    protected Animator anim;
    protected SpriteRenderer sr;

    private Color originalColor;
    public int health;
    protected bool isdead;

    public float flashTime;

    protected Transform playerTransform;
    protected PlayerHealth playerHealth;

    public monster_20_Bar mbr;
    public GameObject canvas;

    public GameObject dropCarrot_1;
    public GameObject dropCarrot_2;
    public GameObject dropCarrot_3;
    public GameObject dropCarrot_4;
    public GameObject dropCarrot_5;
    public GameObject dropCarrot_6;
    public GameObject dropCarrot_7;
    public GameObject dropCarrot_8;
    public GameObject dropCarrot_9;
    public GameObject dropCarrot_10;
    void Start()
    {
        monster_20_Bar.HealthMax = health;
        monster_20_Bar.HealthCurrent = health;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        target = first_change_to_point.position;
        coll.enabled = true;
        sr.enabled = true;
        canvas.SetActive(true);
    }

   void Update()
    {
        Destroy();
        Movement();
        mbr.HealthChange();
    }

    void Movement()
    {
        Dead();
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        Changeposition();
    }

    void OnTriggerEnter2D(Collider2D collision)//标签触发
    {
        if (collision.tag == "player_into")//人物进入攻击范围
        {
            target = playerTransform.position;
        }
        if (collision.tag == "Player")//接触到敌人发起攻击
        {
            anim.SetBool("attack", true);
            anim.SetBool("walk", false);
        }
        if (collision.tag == "player_attack")//人物攻击(主动)
        {
            health--;
            monster_20_Bar.HealthCurrent = health;
            Flashcolor(flashTime);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);//生成单例,血粒子特效
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("attack", false);
            anim.SetBool("walk", true);
        }
    }
    void Changeposition()//转身
    {
        if (Mathf.Abs((transform.position - last_point.position).sqrMagnitude) < 0.1f)
        {
            target = first_point.position;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Mathf.Abs((transform.position - first_point.position).sqrMagnitude) < 0.1f)
        {
            target = last_point.position;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    protected void Flashcolor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }
    protected void ResetColor()
    {
        sr.color = originalColor;
    }

    protected void Dead()//health值减到0,触发死亡动画,在播放完死亡动画后触发Destroy函数
    {
        if (health <= 0)
        {
            isdead = true;
            Instantiate(dropCarrot_1, transform.position, Quaternion.identity);
            Instantiate(dropCarrot_2, transform.position, Quaternion.identity);
            Instantiate(dropCarrot_3, transform.position, Quaternion.identity);
            Instantiate(dropCarrot_4, transform.position, Quaternion.identity);
            Instantiate(dropCarrot_5, transform.position, Quaternion.identity);
            Instantiate(dropCarrot_6, transform.position, Quaternion.identity);
            Instantiate(dropCarrot_7, transform.position, Quaternion.identity);
            Instantiate(dropCarrot_8, transform.position, Quaternion.identity);
            Instantiate(dropCarrot_9, transform.position, Quaternion.identity);
            Instantiate(dropCarrot_10, transform.position, Quaternion.identity);
            return;
        }
        else
        {
            isdead = false;
        }
    }

    protected void Destroy()//加事件帧,不能在前面被调用
    {
        if (isdead == true)
        {
            Destroy(gameObject);
            canvas.SetActive(false);
        }
    }
}
