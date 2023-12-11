using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skull_shadow : MonoBehaviour
{
    private Transform playerTransform;
    private SpriteRenderer sr;
    private SpriteRenderer player_sr;
    private Color color;

    public float activeTime;//控制时间
    public float activeStart;

    private float alpha;//控制不透明度
    public float alphaSet;//初始值
    public float alphaMultiplier;

    private void OnEnable()//残影
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
            shadow_pool.instance.ReturnPool(this.gameObject);//添加到队列
        }

    }
}
