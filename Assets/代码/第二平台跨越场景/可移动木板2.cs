using System.Collections.Generic;
using UnityEngine;

public class 可移动木板2 : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    public float Speed = 1f;

    public Transform left_point, right_point;
    private Vector3 target;

    float stoptime = 0f;
    float defaultStoptime = 0.000005f;

    private Transform playerTransform;
    private Transform playerDefTransform;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        target = left_point.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    void Update()
    {

        Movement();
        if (stoptime > 0)
        {
            stoptime -= Time.fixedDeltaTime;
        }
    }
    void Movement()
    {
        if (playerTransform != null || stoptime > 0)
        {

            transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);

            targetChange();
        }
    }
    void targetChange()
    {
        if (Mathf.Abs((transform.position - left_point.position).sqrMagnitude) < 0.1f)
        {
            stoptime = defaultStoptime;
            target = right_point.position;
        }
        else if (Mathf.Abs((transform.position - right_point.position).sqrMagnitude) < 0.1f)
        {
            stoptime = defaultStoptime;
            target = left_point.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(1);
        if (other.collider.CompareTag("Player"))
        {

            other.gameObject.transform.parent = gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.transform.parent = playerDefTransform;
        }
    }
}
