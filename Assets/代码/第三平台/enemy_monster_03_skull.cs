using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_monster_03_skull : MonoBehaviour
{
    public float Speed;
    public float damage;
    public float distroyDistance;

    Rigidbody2D rb;
    Vector3 startPos;

    Transform playerTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb.velocity = ((Vector2)playerTransform.position - (Vector2)transform.position) * Speed;
       
        startPos = transform.position;

    }

    void Update()
    {
        float distance = (transform.position - startPos).sqrMagnitude;
        Debug.Log(transform.position-startPos);
        if(distance >distroyDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision .tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
