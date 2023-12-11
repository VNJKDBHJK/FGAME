using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   // public int health;
    public int Blinks;
    public float time;
    private Renderer myRenderer;
    Animator anim;
    private ScreenFlash sf;

   public bool isdead;
    public qwe QWE;

    void Start()
    {
        QWE = GetComponent<qwe>();
        Bar.HealthMax = STATIC.health;
        Bar.HealthCurrent = STATIC.health;
        myRenderer = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        sf = GetComponent<ScreenFlash>();//脚本挂在同一个对象上面可以直接这样获取组件
    }

    void Update()
    {
        Bar.HealthCurrent = STATIC.health;
        if (STATIC.count <= 0)
        {
            anim.Play("knockback");
            isdead = true;
            return;
        }
    }
    void BlinkPlayer(int numBlinks,float seconds)//角色受伤后闪烁效果(次数,时间)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));//协程函数
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for(int i = 0; i < numBlinks * 2; i++)
        {
            myRenderer.enabled = !myRenderer.enabled;//可以直接这么切换TRUE FALSE
            yield return new WaitForSeconds(seconds);//等待时间
        }
        myRenderer.enabled = true;
    }

    public void DamagePlayer(int damage)
    {
        sf.FlashScreen();
       STATIC. health -= damage;
        if(STATIC. health >= 100)
        {
            STATIC.health = 100;
        }
        if (STATIC.health <= 0)
        {
            if (STATIC.health <= 0)
            {
                STATIC.health = 0;
            }
            Dead();
        }
        BlinkPlayer(Blinks, time);//敌人受伤时闪烁
    }
    protected void Dead()//health值减到0,触发死亡动画,在播放完死亡动画后触发Destroy函数
    {
        if (STATIC.health <= 0 )
        {
            anim.Play("knockback");
            isdead = true;
            return;
        }
        else
        {
            isdead = false;
        }
    }
}
