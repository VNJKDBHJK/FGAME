using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_monster_01_00 : enemy
{
    private Vector3 target;
    public Transform first_point, last_point;
    public Transform first_change_to_point;

    public float Speed;
    public float bigRange;
    public float smallRange; 

    public GameObject spikesPrefab;
    new void Start()
    {
        base.Start();
        coll.enabled = true;
        sr.enabled = true;
        target = transform.position;
    }

    new void Update()
    {
        base.Update();
        Movement();
        Distance();
    }

    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }

    void Distance()
    {
        float length=Mathf .Abs(((Vector2)transform .position -(Vector2)playerTransform .position).sqrMagnitude );
        if (length < bigRange)
        {
            anim.SetBool("idle", false);
            anim.SetBool("attack", false);
            anim.SetBool("walk", true);
            Changeposition();
            if(length<smallRange)
            {
                anim.SetBool("walk", false);
                anim.SetBool("idle", false);
                anim.SetBool("attack",true);
                Attack();
            }
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("attack", false);
            anim.SetBool("idle", true);
        }
    }
    void Attack()
    {
        Instantiate(spikesPrefab);
    }

    void Changeposition()//×ªÉí
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
