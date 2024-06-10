using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigbook : MonoBehaviour
{
    public GameObject canvas;
    private bool ishear;

    private Transform playerTransform;

    /*  private void OnTriggerEnter2D(Collider2D other)
      {
          ishear = true;
      }
      private void OnTriggerExit2D(Collider2D other)
      {
          ishear = false;
      }*/
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - playerTransform.position).sqrMagnitude;
        if (Mathf.Abs(distance) <= 30)
        {
            ishear = true;
        }
        else
        {
            ishear = false;
        }
        if (ishear)
        {
            canvas.SetActive(true);
        }
        else if (ishear == false)
        {
            canvas.SetActive(false);
        }
    }
}
