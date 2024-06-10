using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monster_03_bar : MonoBehaviour
{
    public static int HealthCurrent;
    public static int HealthMax = 100;

    private Image healthBar;

    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    void Update()
    {
    }
    public void Healthchange()
    {

        healthBar.fillAmount = (float)HealthCurrent / (float)HealthMax;
    }
}
