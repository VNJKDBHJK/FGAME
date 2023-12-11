using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCCChest1 : MonoBehaviour
{
   protected  Animator anim;

    public  GameObject canvas;
    protected bool ishear;

    protected  Transform playerTransform;
    protected  qwe QWE;

   protected  bool isopen;


   protected  void Start()
    {
        QWE = qwe.Instance;
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


   protected virtual  void Update()
    {
        float distance = (transform.position - playerTransform.position).sqrMagnitude;
        if (Mathf.Abs(distance) <= 2)
        {
            ishear = true;
        }
        else
        {
            ishear = false;
        }
    }
    protected  void Destroy()
    {
        if (isopen)
        {
            Destroy(gameObject);
        }
    }
}
