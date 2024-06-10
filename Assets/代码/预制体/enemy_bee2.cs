using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bee2 : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed=5f;
    public Vector2 direction;

    const float defaultDirectionTime = 5f;
    float directionTime = defaultDirectionTime;

    const float defaultChangeDirectionTime = 0.5f;
    public float changeDirectionTime = 0f;

    const float defaultAttackedTime = 10f;
    float attackedTime = 0f;

    public Vector2 playerPos;
    float range = 8;//��Χ
    float distance = 0f;//��������Ҿ���

    public float limit_x_min;
    public float limit_x_max;
    public float limit_y_max;
    public float limit_y_min;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    //�����ڱ���ҹ���������ʱ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("ground") && changeDirectionTime <= 0))
        {
            Debug.Log(111);
            Vector2 v2 = new Vector2(rb.velocity.x, Random.Range(0f, 10.0f));//���ڵ�����ʱ��ȡ���ϵ��������
            direction = v2.normalized;
            changeDirectionTime = defaultChangeDirectionTime;
        }
        if (collision.CompareTag("Player"))
        {
            attackedTime = defaultAttackedTime;//���ʱ��Ϊ10f
        }
    }
    //��ȡ�������
    void SetRandomDirection()
    {
        Vector2 v2 = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));//�������x,y
        direction= v2.normalized;
    }
    private void Update()
    {
        if (changeDirectionTime > 0)
        {
            changeDirectionTime -= Time.deltaTime;
        }
         
        SetAnim();
        if (transform.position.x < limit_x_min )
        {
            Vector2 v2 = new Vector2(Random.Range(0f, 10.0f), Random.Range(-10.0f, 10.0f));
            direction = v2.normalized;
        }
        if (transform.position.x > limit_x_max)
        { 
        Vector2 v2 = new Vector2(Random.Range(-10.0f,0f), Random.Range(-10.0f, 10.0f));
        direction = v2.normalized;
        }
        if (transform.position.y >limit_y_min )
        {
            Vector2 v2 = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 0f));
            direction = v2.normalized;
        }
        if (transform.position.y > limit_y_max)
        {
            Vector2 v2 = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(0f, 10.0f));
            direction = v2.normalized;
        }
        GetDistance();
        if (distance <= range || attackedTime > 0)//����ҽ������Ŀ�귶Χʱ&&�������յ���ҹ���ʱ
        {
            FollowPlayer();//׷�����
        }
        else
        {
            Walk();//�������
        }
    }
    void FixedUpdate()
    {
      
    }
    //��ȡ����
    void GetDistance()
    {
        if (qwe.Instance != null)
        {
            GameObject player = qwe.Instance.gameObject;//����
            playerPos = player.transform.position;//��ȡ���λ��
            distance = (playerPos - (Vector2)transform.position).magnitude;
        }
    }
    //׷�����
    void FollowPlayer()
    {
        attackedTime -= Time.deltaTime;//�ڳ��ʱ�䷶Χ��׷�����
        direction = (playerPos - (Vector2)transform.position).normalized;//��ȡ���λ���ٽ����ɵ�λ����
        float length = (playerPos - (Vector2)transform.position).magnitude;
        if (length < 0.1f)
        {

        }
        else
        {
            rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
        }
      //��bug
    }
    //�漴����
    void Walk()
    {
        if (directionTime > 0)
        {
            directionTime -= Time.deltaTime;
        }
        else
        {
            SetRandomDirection();
            directionTime = defaultDirectionTime;
        }
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)direction);
    }
    void SetAnim()
    {
        if (direction.x < 0f )
        {
            transform.localScale= new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
