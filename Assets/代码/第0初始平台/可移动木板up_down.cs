using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 可移动木板up_down : MonoBehaviour
{
    public float Speed = 1f;

    public Transform first_point, second_point;
    public Transform first_change_to_point;
    private Vector3 target;

    float stoptime = 0f;
    float defaultStoptime = 0.000005f;

    private Transform playerTransform;
    private Transform playerDefTransform;

    void Start()
    {
        target = first_change_to_point.position;
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
        if (Mathf.Abs((transform.position - first_point.position).sqrMagnitude) < 104f)
        {
            stoptime = defaultStoptime;
            target = second_point.position;
        }
        else if (Mathf.Abs((transform.position - second_point.position).sqrMagnitude) < 104f)
        {
            stoptime = defaultStoptime;
            target = first_point.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
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
