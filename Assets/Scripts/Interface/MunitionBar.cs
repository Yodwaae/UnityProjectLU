using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MunitionBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMunition(int munition)
    {
        slider.maxValue = munition;
        slider.value = munition;
    }

    public void SetMunition(int munition)
    {
        slider.value = munition;
    }
}
