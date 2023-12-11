using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bee1 : enemy
{
    public Transform left_point;
    public Transform middle_point1,middle_point2,middle_point3,middle_point4;
    public Transform right_point;
    public float speed;
    public Vector3 target;
    new void Start()
    {
        base.Start();
        target = left_point.position;
    }
    new void Update()
    {
        base.Update();
        Movement();
    }
    void Movement()
    {
        if(Vector2.Distance(transform.position, target) < 0.1f)
        {
            Switchpoint();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
    void Switchpoint()
    {
        if (target == right_point.position)
        {
            transform.localScale = new Vector3(1, 1, 1);
            target = middle_point1.position;
        }
        else if (target == middle_point1.position)
        {
            target = middle_point2.position;
        }
        else if (target == middle_point2.position)
        {
            target = middle_point3.position;
        }
        else if (target == middle_point3.position)
        {
            target = middle_point4.position;
        }
        else if (target == middle_point4.position)
        {
            target = left_point.position;
        }
        else if (target == left_point.position)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            target = right_point.position;
        }
    }
}
