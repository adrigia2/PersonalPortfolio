using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    Health health;

    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.minValue = health.min;
        slider.maxValue = health.max;
        slider.value = health.max;
    }

    // Update is called once per frame
    public void UpdateUI()
    { 
        slider.value = health.health;
    }
}
