using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monster_07_bar : MonoBehaviour
{
    //public GameObject canvas;

    public float TimeMax;
    private float Time_reduce;
    public float Speed;

    private Image Bar;
    void Start()
    {
        Bar = GetComponent<Image>();
        Time_reduce = TimeMax;
    }

    void Update()
    {
        
    }

   public void  HealthChange()
    {
        Time_reduce = TimeMax - 1 * Speed * Time.deltaTime;
        Bar.fillAmount = (float)Time_reduce / (float)TimeMax;
        if (Time_reduce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
