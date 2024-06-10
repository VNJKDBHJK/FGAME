using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monster_bar : MonoBehaviour
{
    public  int HealthCurrent;
    public  int HealthMax;

    private Image healthBar;

    void Start()
    {
        healthBar = GetComponent<Image>();
/*        HealthCurrent = HealthMax=gameObject .transform .parent .transform .parent .gameObject .GetComponent<>;*/
    }

    void Update()
    {
        HealthChange();
    }
    public void HealthChange()
    {
        healthBar.fillAmount = (float)HealthCurrent / (float)HealthMax;
    }
}
