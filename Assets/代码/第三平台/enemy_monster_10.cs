using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_monster_10 : enemy
{
    private Vector3 target;
    public Transform left_point, right_point;

    public float Speed;
    Vector2 direction;

    float stoptime = 0f;
    float defaultStoptime = 0.000005f;

    float deadtime = 0f;
    float defaultdeadtime = 0.000005f;

    bool isrun;
    bool isright;
    bool isleft;
    bool ishurt;
    public int count_run=0;

    public GameObject canvas;
    new void Start()
    {
        base.Start();
        coll.enabled = true;
        sr.enabled = true;
        target = right_point.position;
        canvas.SetActive(true);
/*        monster_10_Bar.HealthMax = health;
        monster_10_Bar.HealthCurrent = health;*/
    }

    new void Update()
    {
        base.Update();
        Movement();
        if (stoptime > 0)
        {
            stoptime -= Time.fixedDeltaTime;
        }
        if (deadtime> 0)
        {
            deadtime -= Time.fixedDeltaTime;
        }
    }
    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        Changeposition();
        Getin();
        Run();
    }
    void Changeposition()
    {
        if (Mathf.Abs((transform.position - right_point.position).sqrMagnitude) < 1f&&ishurt==false)
        {
            target = left_point.position;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Mathf.Abs((transform.position - left_point.position).sqrMagnitude) < 1f&&ishurt==false)
        {
            target = right_point.position;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    //¹¥»÷Íæ¼Ò
    void Getin()
    {
        if (playerTransform != null )
        {
            if (right_point.position.x > playerTransform.position.x)
            {
                
                direction = (((Vector2)playerTransform.position) - (Vector2)transform.position).normalized;
                float length = (playerTransform.position - transform.position).magnitude;
                if (length < 4f)
                {
                    anim.SetBool("attack", true);
                    anim.SetBool("idle", false);
                }
                else if(length>=4f)
                {
                    rb.MovePosition((Vector2)transform.position + direction * Speed * Time.deltaTime);
                    anim.SetBool("attack", false);
                    anim.SetBool("idle", true);
                }
            }
        }
    }
    protected new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
    void Run()
    {
        if (transform.localScale.x < 0 && isrun == true && isleft == false || isright == true && isleft == false&&isrun==true)
            {
                isright = true;
                transform.localScale = new Vector3(1, 1, 1);
                 if(((transform .position - right_point.position).magnitude)<=1f)
                 {
                anim.SetBool("run", false);
                anim.SetBool("idle", true);
                isrun = false;
                 }
            }
            else if (transform.localScale.x > 0 && isrun == true&&isright==false||isleft==true&&isright==false&&isrun==true)
            {
                isleft = true;
                transform.localScale = new Vector3(-1, 1, 1);
                 if (((transform.position -left_point.position).magnitude) <= 1f)
                 {
                anim.SetBool("run", false);
                anim.SetBool("idle", true);
                isrun = false;
                 }
        }
    }
}
