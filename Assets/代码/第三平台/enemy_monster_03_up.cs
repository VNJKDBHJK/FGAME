using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_monster_03_up : enemy
{
    private Vector3 target;
    public Transform first_point, last_point;
    public Transform first_change_to_point;
    public float Speed;
    public float range;

    private Transform monster_skullTransform;
    private SpriteRenderer monster_skullsr;
    private Collider2D monster_skull_coll;
    private Rigidbody2D monster_skull_rb;
    public float skull_Speed;
    public float distroyDistance;
    Vector3 skull_target;
    Vector3 startPos;

   /* public monster_bar mbr;
    public GameObject canvas;*/
    new void Start()
    {
        base.Start();
        target = first_change_to_point.position;

        monster_skullTransform = GameObject.FindGameObjectWithTag("skull_up").GetComponent<Transform>();
        monster_skullsr = GameObject.FindGameObjectWithTag("skull_up").GetComponent<SpriteRenderer>();
        monster_skull_coll = GameObject.FindGameObjectWithTag("skull_up").GetComponent<Collider2D>();
        monster_skull_rb = GameObject.FindGameObjectWithTag("skull_up").GetComponent<Rigidbody2D>();
        monster_skullsr.enabled = false;
        monster_skull_coll.enabled = false;
        startPos = monster_skullTransform.position;
    }

    new void Update()
    {
        base.Update();
        Movement();
        float distance = Mathf.Abs((monster_skullTransform.position - startPos).sqrMagnitude);//超出攻击范围后取消显示
        if (distance > distroyDistance)
        {
            monster_skullsr.enabled = false;
            monster_skull_coll.enabled = false;
        }
    }

    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        monster_skullTransform.position = Vector2.MoveTowards(monster_skullTransform.position, skull_target, skull_Speed * Time.deltaTime);
        Changeposition();
        Throw();
    }

    void Throw()//在人物和原始角色的距离<一定值的时候,角色开始使用投掷攻击
    {
        float length = Mathf.Abs(((Vector2)playerTransform.position - (Vector2)transform.position).sqrMagnitude);
        if (length < range)
        {
            monster_skull_coll.enabled = true;
            monster_skullsr.enabled = true;
            skull_Speed = 4f;
            skull_target = playerTransform.position;
            monster_skull_rb.velocity = ((Vector2)playerTransform.position - (Vector2)transform.position) * skull_Speed;
            if (length < 4f)
            {
                anim.SetBool("throw", false);
                anim.SetBool("attack", true);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else
            {
                anim.SetBool("throw", true);
                anim.SetBool("attack", false);
            }
        }
        else
        {
            skull_Speed = Speed;
            anim.SetBool("throw", false);
            anim.SetBool("attack", false);
            anim.SetBool("walk", true);
            monster_skull_coll.enabled = false;
            monster_skullsr.enabled = false;
            monster_skullTransform.position = transform.position;
            rb.velocity = new Vector2(0, rb.velocity.y);//将x值化为0
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)//标签触发
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag == "Player")
        {
            monster_skull_coll.enabled = false;
            monster_skullsr.enabled = false;
            monster_skullTransform.position = transform.position;
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
}
