using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active_enemy : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    Animator anim;
    SpriteRenderer sr;
    public int health;

    private Vector3 target;
    public Transform first_point, last_point;
    public Transform first_change_to_point;

    private Transform playerTransform;
    public float Speed;
    int faceTo;

    bool isdead;
    bool isrun;

    float runtime=0f;
    float defaultRuntime=0.0005f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        coll.enabled = true;
        sr.enabled = true;
        target = first_change_to_point.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Movement();
        if (runtime > 0)
        {
            runtime -= Time.deltaTime;
        }
    }

    void Movement()
    {
        Dead();
        Run();
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        Changeposition();
    }

    private void OnTriggerEnter2D(Collider2D collision)//��ǩ����
    {
        if (collision.tag == "player_into")//������빥����Χ
        {
            target = playerTransform.position;
        }

        if (collision.tag == "Player")//�Ӵ������˷��𹥻�
        {
            anim.SetBool("attack", true);
            anim.SetBool("idle", false);
        }

        if (collision.tag == "player_attack")//���﹥��(����)
        {
            health--;
            anim.SetBool("idle", false);
            anim.SetBool("attack", false);
            anim.SetBool("run", true);
            isrun = true;
            runtime = defaultRuntime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("attack", false);
            anim.SetBool("idle", true);
        }
        if (collision.tag == "player_attack"&&runtime<=0f)
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
            else if(distance<=0) faceTo = -1;
            rb.velocity = new Vector2(Speed * faceTo, rb.velocity.y);
            isrun = false;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void Changeposition()//ת��
    {
        if (Mathf.Abs((transform.position - last_point.position).sqrMagnitude) < 0.1f )
        {
            target = first_point.position;
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", false);
        }
        else if (Mathf.Abs((transform.position - first_point.position).sqrMagnitude) < 0.1f )
        {
            target = last_point.position;
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", false);
        }
    }

    void Dead()//healthֵ����0,������������,�ڲ��������������󴥷�Destroy����
    {
        if (health <= 0)
        {
            anim.Play("dead");
            isdead = true;
            return;
        }
        else
        {
            isdead = false;
        }
    }

    private void Destroy()//���¼�֡,������ǰ�汻����
    {
        if (isdead == true)
        {
            coll.enabled = false;
            sr.enabled = false;
            Destroy(gameObject);
        }
    }
}
