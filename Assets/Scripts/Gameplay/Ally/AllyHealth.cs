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
    void OnCollisionEnter2D(Collision2D collision)//Se d�clenche quand la balle touche quelque chose
    {
        //D�truit l'alli� s'il est touch� par le joueur
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject); //d�truit l'alli�
            nbrKillAlly++; //compte le nombre de kill (utile pour le score)
            UI.SetScoreAlly();//Met � jour le score de l'alli�
        }
    }
}
