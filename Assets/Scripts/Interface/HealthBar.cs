using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; //r�f�rence l'objet repr�sentant le nombre de vie dans la barre de vie dans l'interface

    public void SetHealth(int health)
    {
        //Met la barre de sant� au niveau du nombre de points de vie du joueur
        slider.value = health;
    }
}
