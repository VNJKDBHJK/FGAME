using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_02 : MonoBehaviour
{
    Animator anim;

    public GameObject canvas;
    private bool ishear;

    private Transform playerTransform;
    public qwe QWE;
    bool isopen;
    public LayerMask Chest;
    void Start()
    {
        //if(qwe.Instance!=null)
        QWE = qwe.Instance;
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        if (distance <= 2)
        {
            ishear = true;
        }
        else
        {
            ishear = false;
        }
        if (ishear && isopen)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) && ishear)
        {
            Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发射射线
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(myray.origin.x, myray.origin.y), Vector3.forward, 0, Chest);
            if (hit.collider.gameObject.tag == ("Chest_1_1") && QWE.count_1 >= 0)
            { 
                anim.SetBool("IsOpened", true);
                isopen = true;
                QWE.count_1--;
            }
        }
    }
    private void Destroy()
    {
        if (isopen)
        {
            Destroy(gameObject);
        }
    }
}
