using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRed : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    float speed = 5f;
    public Transform position;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Movement()
    {
        if (transform.position.x <= position.position.x) { 
        }
    }
}
