using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; //référence l'objet représentant le nombre de vie dans la barre de vie dans l'interface

    public void SetHealth(int health)
    {
        //Met la barre de santé au niveau du nombre de points de vie du joueur
        slider.value = health;
    }
}
