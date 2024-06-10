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

    public float flashTime;//�����˺�����ʱ��

    protected Transform playerTransform;
    public GameObject bloodEffect;//Ѫ������Ч

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
        originalColor = sr.color;//��¼��ʼ��ɫ
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
        if (collision.tag == "player_attack")//���﹥��(����)
        {
            health--;
            Flashcolor(flashTime);//�ı���ɫ(���˺����Ч)
            Instantiate(bloodEffect, transform.position, Quaternion.identity);//���ɵ���,Ѫ������Ч
        }
        if (collision.tag == "Player")//����ɫ����˺�
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
        Invoke("ResetColor", time);//����������������������������溯��
    }
   protected  void ResetColor()
    {
        sr.color = originalColor;//�ı���ɫ
    }


    protected  void Dead()//healthֵ����0,������������,�ڲ��������������󴥷�Destroy����
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

    protected  void Destroy()//���¼�֡,������ǰ�汻����
    {
        if (isdead == true)
        {
            //canvas.SetActive(false);
            Destroy(gameObject);
        }
    }
}
