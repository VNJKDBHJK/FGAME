using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class monster_20_Bar : MonoBehaviour
{
    public static int HealthCurrent;
    public static int HealthMax;

    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        HealthCurrent = HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HealthChange()
    {
        healthBar.fillAmount = (float)HealthCurrent / (float)HealthMax;
    }
}
