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
    float range = 8;//范围
    float distance = 0f;//敌人与玩家距离

    public float limit_x_min;
    public float limit_x_max;
    public float limit_y_max;
    public float limit_y_min;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    //敌人在被玩家攻击后赋予仇恨时间
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("ground") && changeDirectionTime <= 0))
        {
            Debug.Log(111);
            Vector2 v2 = new Vector2(rb.velocity.x, Random.Range(0f, 10.0f));//踩在地面上时获取向上的随机方向
            direction = v2.normalized;
            changeDirectionTime = defaultChangeDirectionTime;
        }
        if (collision.CompareTag("Player"))
        {
            attackedTime = defaultAttackedTime;//仇恨时间为10f
        }
    }
    //获取随机方向
    void SetRandomDirection()
    {
        Vector2 v2 = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));//随机生成x,y
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
        if (distance <= range || attackedTime > 0)//当玩家进入敌人目标范围时&&当敌人收到玩家攻击时
        {
            FollowPlayer();//追踪玩家
        }
        else
        {
            Walk();//随机方向
        }
    }
    void FixedUpdate()
    {
      
    }
    //获取距离
    void GetDistance()
    {
        if (qwe.Instance != null)
        {
            GameObject player = qwe.Instance.gameObject;//单例
            playerPos = player.transform.position;//获取玩家位置
            distance = (playerPos - (Vector2)transform.position).magnitude;
        }
    }
    //追踪玩家
    void FollowPlayer()
    {
        attackedTime -= Time.deltaTime;//在仇恨时间范围内追踪玩家
        direction = (playerPos - (Vector2)transform.position).normalized;//获取玩家位置再将其变成单位向量
        float length = (playerPos - (Vector2)transform.position).magnitude;
        if (length < 0.1f)
        {

        }
        else
        {
            rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
        }
      //有bug
    }
    //随即方向
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
