using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_slug1 : enemy
{
    public float Speed;
    public Transform left_point, middle_point1,middle_point2,middle_point3, middle_point4, middle_point5, middle_point6,right_point;
    public Vector3 target;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        target = left_point.position;
    }

    // Update is called once per frame
     new void Update()
    {
        base.Update();
        Movement();
    }
    void Movement()
    {
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            Switchpoint();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        }
    }
    void Switchpoint()
    {
        if (target == middle_point1.position)
        {
            target = middle_point2.position;
        }
        else if (target == middle_point2.position)
        {
            target = middle_point3.position;
        }
        else if (target == middle_point3.position)
        {
            target = right_point.position;
        }
        else if (target == left_point.position)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            target = middle_point1.position;
        }
        else if (target == right_point.position)
        {
            transform.localScale = new Vector3(1, 1, 1);
            target = middle_point4.position;
        }
        else if (target == middle_point4.position)
        {
            target = middle_point5.position;
        }
        else if (target == middle_point5.position)
        {
            target = middle_point6.position;
        }
        else if (target == middle_point6.position)
        {
            target = left_point.position;
        }
    }
}
