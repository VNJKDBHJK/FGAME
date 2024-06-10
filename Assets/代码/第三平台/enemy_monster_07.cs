using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_monster_07: MonoBehaviour
{
   Rigidbody2D rb;
   Collider2D coll;
    Animator anim;
    SpriteRenderer sr;
    const float defaultChangeDirectionTime = 0.00005f;
    float changeDirectionTime = 0f;

    float range = 4f;

    private Color originalColor;
    public int health;
    public int damage;
    protected bool isdead;

    public float flashTime;

    protected Transform playerTransform;
    private PlayerHealth playerHealth;

    //private monster_07_bar mbr;
    public monster_07_bar mbr;
    public GameObject canvas;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        //mbr = GetComponent<monster_07_bar>();
        canvas.SetActive(false);
        coll.enabled = false;
        sr.enabled = false;
    }
     void Update()
    {

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        changestate();
        if (changeDirectionTime > 0)
        {
            changeDirectionTime -= Time.deltaTime;
        }
    }
    void changestate()
    {
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            if (Mathf.Abs(distance) < range)
            {
                sr.enabled = true;
                coll.enabled = true;
                canvas.SetActive(true);
                /* changeDirectionTime = defaultChangeDirectionTime;*/
                anim.SetBool("idle", false);
                anim.SetBool("appear", true);
                mbr.HealthChange();
            }
            else
            {
                anim.SetBool("appear", false);
                anim.SetBool("idle", true);
            }

        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision .tag == "Player")
        {
            anim.SetBool("idle", false);
            anim.SetBool("appear", false);
            anim.SetBool("attack", true);
            isdead = true;
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }
        }
    }
    protected void Destroy()//加事件帧,不能在前面被调用
    {
        if (isdead == true)
        {
            coll.enabled = false;
            sr.enabled = false;
            Destroy(gameObject);
        }
    }
}
