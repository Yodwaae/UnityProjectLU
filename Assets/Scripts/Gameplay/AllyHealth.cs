using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHealth : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)//Se d�clenche quand la balle touche quelque chose
    {
            //D�truit l'alli� s'il est touch� par le joueur
            if (collision.gameObject.tag == "bullet") 
                Destroy(gameObject);
    }
}
