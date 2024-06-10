using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Collider2D coll;
    protected Animator anim;
    protected SpriteRenderer sr;

    public  Color originalColor;
    public int health;
    public int damage;
    protected bool isdead;

    public float flashTime;//敌人伤害后红光时间

    protected Transform playerTransform;
    public GameObject bloodEffect;//血粒子特效

    protected PlayerHealth playerHealth;

    public monster_bar mbr;

    public GameObject dropStar;
    //public GameObject canvas;
    protected void Start()
    {
        mbr.HealthMax = health;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;//记录初始颜色
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>(); 
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //mbr=GetComponent <monster_bar >();
       //canvas.SetActive(true);
    }
    protected void Update()
    {

        mbr.HealthCurrent = health;
        Dead();
        //mbr.HealthChange();
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player_attack")//人物攻击(主动)
        {
            health--;
            Flashcolor(flashTime);//改变颜色(敌人红光特效)
            Instantiate(bloodEffect, transform.position, Quaternion.identity);//生成单例,血粒子特效
        }
        if (collision.tag == "Player")//给角色添加伤害
        {
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }
        }
    }
    protected  void Flashcolor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);//在这个函数成立的条件下启用下面函数
    }
   protected  void ResetColor()
    {
        sr.color = originalColor;//改变颜色
    }


    protected  void Dead()//health值减到0,触发死亡动画,在播放完死亡动画后触发Destroy函数
    {
        if (health <= 0)
        {
            health = 0;
            anim.Play("dead");
            Instantiate(dropStar, transform.position, Quaternion.identity);
            isdead = true;
            return;
        }
        else
        {
            isdead = false;
        }
    }

    protected  void Destroy()//加事件帧,不能在前面被调用
    {
        if (isdead == true)
        {
            //canvas.SetActive(false);
            Destroy(gameObject);
        }
    }
}
