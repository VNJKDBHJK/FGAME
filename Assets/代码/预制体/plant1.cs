using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant1 : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    SpriteRenderer sr;
 
    private Transform playerTransform;
    private PlayerHealth playerHealth;

    const float defaultChangeDirectionTime = 0.00005f;
    float changeDirectionTime = 0f;

    float range = 8f;
    public int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        coll.enabled = false;
        sr.enabled = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        changestate();
        if (changeDirectionTime > 0)
        {
            changeDirectionTime-=Time.deltaTime;
        }
    }
    void changestate()
    {

        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            if (Mathf.Abs(distance) < range|| changeDirectionTime>0)
            {
                sr.enabled = true;
                coll.enabled = true;
                changeDirectionTime = defaultChangeDirectionTime;
            }
            else
            {
                sr.enabled = false;
                coll.enabled = false;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")//¸ø½ÇÉ«Ìí¼ÓÉËº¦
        {
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }
        }
    }
}
