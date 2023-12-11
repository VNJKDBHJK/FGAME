using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_monster_02_spike : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    Animator anim;
    SpriteRenderer sr;
    public float Speed;
    public int whichone;
    public float range;

    Vector3 startPos;

    private Animator parent_anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        parent_anim =GameObject.FindGameObjectWithTag("parent_moving").GetComponent<Animator>();
        coll.enabled = false;
        sr.enabled = false;
        startPos =transform .position ;
       Switch();
    }

    void Update()
    {
        
        Destroy();
    }
    void Switch()
    {
        if(whichone == 1)
        {
            transform.localScale = new Vector3(0, 0, 0);
            transform.localPosition = new Vector3(-1, -1, 0);
            rb.velocity = new Vector2(Speed, rb.velocity.y);
        }else if(whichone == 2)
        {
            transform.localScale = new Vector3(0, 0, -40);
            transform.localPosition = new Vector3(-1, 0, 0);
            rb.velocity = new Vector2(Speed, Speed);
        }
        else if (whichone == 3)
        {
            transform.localScale = new Vector3(0, 0, -90);
            transform.localPosition = new Vector3(0, 1, 0);
            rb.velocity = new Vector2(rb.velocity.x, Speed);
        }
        else if (whichone == 4)
        {
            transform.localScale = new Vector3(0, 0, 40);
            transform.localPosition = new Vector3(1, 0, 0);
            rb.velocity = new Vector2(-Speed, -Speed);
        }
        else if(whichone == 5)
        {
            transform.localScale = new Vector3(0, 0, 0);
            transform.localPosition= new Vector3(1, -1, 0);
           rb.velocity = new Vector2(-Speed, rb.velocity.y);
        }
    }
    private void Destroy()
    {
        float length = Mathf.Abs(((Vector2)transform.position - (Vector2)startPos).sqrMagnitude);
        if (length <range)
        {
            coll.enabled = true;
            sr.enabled =true;
        }
        else
        {
            coll.enabled = false;
            sr.enabled = false;
        }
    }
}
