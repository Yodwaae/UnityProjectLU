using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHealth : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)//Se déclenche quand la balle touche quelque chose
    {
            //Détruit l'allié s'il est touché par le joueur
            if (collision.gameObject.tag == "bullet") 
                Destroy(gameObject);
    }
}
