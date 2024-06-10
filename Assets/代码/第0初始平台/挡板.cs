using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 挡板 : MonoBehaviour
{
    public qwe QWE;

    public GameObject canvas;
    private bool ishear;
    Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        QWE = qwe.Instance;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        canvas.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
        ishear = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        if (distance <= 2)
        {
            ishear = true;
        }
        if (ishear)
        {
            canvas.SetActive(true);
        }
        if (QWE.lock_key_01 && QWE.lock_key_02)
        {
            Destroy(gameObject);
        }
    }

}
