using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_monster_08 : enemy
{
    private Vector3 target;
    Vector3 startPos;
    public float Speed;
    new  void Start()
    {
        base.Start();
        coll.enabled = true;
        sr.enabled = true;
        target =transform .position ;
        startPos = transform.position;
    }

    new void Update()
    {
        base.Update();
        Movement();
        if(transform .position ==startPos)
        {
            anim.SetBool("idle", true);
            anim.SetBool("creep", false);
        }
    }

    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }

    protected  override void OnTriggerEnter2D(Collider2D collision)//标签触发
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag == "pplayer")//人物进入攻击范围
        {
            anim.SetBool("creep", true);
            anim.SetBool("idle", true);
            target = playerTransform.position;
        }

        if (collision.tag == "Player")//接触到敌人发起攻击
        {
            anim.SetBool("idle", false);
            anim.SetBool("creep", false);
            anim.SetBool("attack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "player_into")
        {
            target = startPos;
        }
        if (collision.tag == "Player")
        {
            anim.SetBool("attack", false);
            anim.SetBool("creep", true);
            target = startPos;
        }
    }
}
