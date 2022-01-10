using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHealth : MonoBehaviour
{
    static int nbrKillAlly;
    private Interface UI;

    public void Awake()
    {
        UI = GameObject.FindGameObjectWithTag("Interface").GetComponent<Interface>();
    }
    void OnCollisionEnter2D(Collision2D collision)//Se déclenche quand la balle touche quelque chose
    {
        //Détruit l'allié s'il est touché par le joueur
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject); //détruit l'allié
            nbrKillAlly++; //compte le nombre de kill (utile pour le score)
            UI.SetScoreAlly();//Met à jour le score de l'allié
        }
    }
}
