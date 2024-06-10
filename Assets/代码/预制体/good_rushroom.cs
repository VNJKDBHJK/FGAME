using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class good_rushroom : MonoBehaviour
{
    Collider2D coll;
    SpriteRenderer sr;

    public Color originalColor;
    public float flashTime;

    void Start()
    {
        coll = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;//��¼��ʼ��ɫ
        coll.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
         if (Input.GetButton("Pick")&&collision.tag=="Player")
         {
            Flashcolor(flashTime);
            if (collision.GetComponent<PlayerHealth>() != null)
            {
                collision.GetComponent<PlayerHealth>().DamagePlayer(-4);
            }
         }
    }

    protected void Flashcolor(float time)
    {
        sr.color = Color.green;
        Invoke("ResetColor", time);//����������������������������溯��
    }
    protected void ResetColor()
    {
        sr.color = originalColor;//�ı���ɫ
        Destroy(gameObject);
    }
}
