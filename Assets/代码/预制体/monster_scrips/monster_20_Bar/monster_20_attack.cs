using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_20_attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")//�Ӵ������˷��𹥻�
        {

            if (collision.GetComponent <PlayerHealth >() != null)
            {
                collision.GetComponent<PlayerHealth>().DamagePlayer(4);
            }
        }
    }
}
