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
        sf = GetComponent<ScreenFlash>();//�ű�����ͬһ�������������ֱ��������ȡ���
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
    void BlinkPlayer(int numBlinks,float seconds)//��ɫ���˺���˸Ч��(����,ʱ��)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));//Э�̺���
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for(int i = 0; i < numBlinks * 2; i++)
        {
            myRenderer.enabled = !myRenderer.enabled;//����ֱ����ô�л�TRUE FALSE
            yield return new WaitForSeconds(seconds);//�ȴ�ʱ��
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
        BlinkPlayer(Blinks, time);//��������ʱ��˸
    }
    protected void Dead()//healthֵ����0,������������,�ڲ��������������󴥷�Destroy����
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
