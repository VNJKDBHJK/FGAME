using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_06 : MonoBehaviour
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
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        Debug.Log(QWE.count_2);
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
            Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);//���������������
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(myray.origin.x, myray.origin.y), Vector3.down, 0, Chest);//�����߼��ͼ��
            if (hit.collider.gameObject.tag == ("Chest") && QWE.count_2 >= 0)
            {
                anim.SetBool("IsOpened", true);
                isopen = true;
                //QWE.ATTACK_02 = true;
                QWE.lock_key_02 = true;
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
