using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Text healthText;
    public static int HealthCurrent;
    public static int HealthMax=100;

    private Image healthBar;

    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    
    void Update()
    {
        healthBar.fillAmount = (float)HealthCurrent /(float ) HealthMax;
        healthText.text = HealthCurrent.ToString() + "/" + HealthMax.ToString();
    }
}
