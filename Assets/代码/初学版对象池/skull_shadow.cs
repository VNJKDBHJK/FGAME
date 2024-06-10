using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skull_shadow : MonoBehaviour
{
    private Transform playerTransform;
    private SpriteRenderer sr;
    private SpriteRenderer player_sr;
    private Color color;

    public float activeTime;//����ʱ��
    public float activeStart;

    private float alpha;//���Ʋ�͸����
    public float alphaSet;//��ʼֵ
    public float alphaMultiplier;

    private void OnEnable()//��Ӱ
    {
        playerTransform = GameObject.FindGameObjectWithTag("skull").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        player_sr = GameObject.FindGameObjectWithTag("skull").GetComponent<SpriteRenderer>();
        alpha = alphaSet;

        sr.sprite = player_sr.sprite;
        transform.localScale = playerTransform.localScale;
        transform.rotation = playerTransform.rotation;

        activeStart = Time.time;
    }

    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(1, 1, 1, alpha);
        sr.color = color;

        if(Time.time >=activeStart + activeTime)
        {
            shadow_pool.instance.ReturnPool(this.gameObject);//��ӵ�����
        }

    }
}
