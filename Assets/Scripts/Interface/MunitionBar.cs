using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MunitionBar : MonoBehaviour
{
    public Slider slider;//objet représentant le nombre de munition dans l'interface

    public void SetMaxMunition(int munition)
    {
        //met la barre au complet quand le nombre de munition est au maximum
        slider.maxValue = munition;
        slider.value = munition;
    }

    public void SetMunition(int munition)
    {
        //met la barre de munition à la hauteur du nombre de munition qu'il reste
        slider.value = munition;
    }
}
