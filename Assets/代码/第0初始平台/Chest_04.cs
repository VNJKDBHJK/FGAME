using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_04 : MonoBehaviour
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
        //if (qwe.Instance != null)
        QWE = qwe.Instance;
        anim = GetComponent<Animator>();
        playerTransform = QWE.transform;
    }


    void Update()
    {
        float distance = Vector2 .Distance(transform.position ,playerTransform.position);
        if (distance<= 2)
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
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(myray.origin.x, myray.origin.y), Vector3.down,0,Chest);//用射线检测图层
            if (hit.collider.gameObject.tag == ("Chest") && QWE.count_2 >= 0)
            {
                anim.SetBool("IsOpened", true);
                isopen = true;
                QWE.ATTACK_05 = true;
                QWE.count_2--;
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
