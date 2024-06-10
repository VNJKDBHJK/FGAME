using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_monster_11 : enemy
{
    private Vector3 target;
    public Transform first_point, last_point;
    public Transform first_change_to_point;

    public float Speed;
    int faceTo;
    bool isrun;
    new void  Start()
    {
        base.Start();
        coll.enabled = true;
        sr.enabled = true;
        target = first_change_to_point.position;
    }

    new void Update()
    {
        base.Update();
        Movement();
    }

    void Movement()
    {
        Run();
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        Changeposition();
    }

    protected override  void OnTriggerEnter2D(Collider2D collision)//标签触发
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag == "player_into")//人物进入攻击范围
        {
            target = playerTransform.position;
        }

        if (collision.tag == "Player")//接触到敌人发起攻击
        {
            anim.SetBool("attack", true);
            anim.SetBool("idle", false);
        }

        if (collision.tag == "player_attack")//人物攻击(主动)
        {
            anim.SetBool("idle", false);
            anim.SetBool("attack", false);
            anim.SetBool("run", true);
            isrun = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("attack", false);
            anim.SetBool("idle", true);
        }
        if (collision.tag == "player_attack" )
        {
            isrun = false;
        }
    }
    void Run()
    {
        if (isrun == true)
        {

            float distance = playerTransform.position.x - transform.position.x;
            if (distance > 0) faceTo = 1;
            else if (distance <= 0) faceTo = -1;
            rb.velocity = new Vector2(Speed * faceTo, rb.velocity.y);
            isrun = false;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void Changeposition()//转身
    {
        if (Mathf.Abs((transform.position - last_point.position).sqrMagnitude) < 0.1f)
        {
            target = first_point.position;
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", false);
        }
        else if (Mathf.Abs((transform.position - first_point.position).sqrMagnitude) < 0.1f)
        {
            target = last_point.position;
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", false);
        }
    }
 
}
