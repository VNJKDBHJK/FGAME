using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_monster_18 : MonoBehaviour
{
    public int damage;

    protected PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//¸ø½ÇÉ«Ìí¼ÓÉËº¦
        {
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }

        }
    }
}
