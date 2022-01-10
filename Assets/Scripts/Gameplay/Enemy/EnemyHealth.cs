using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]//permet d'accéder à la variable dans l'éditeur tout en là laissant privée
    private int vie;//Créer la variable de vie de l'ennemi
    private Interface UI;
    private GameObject gManager;//Créer la référence au GameManager
    static int nbrKillEnemy;
    //private SpawnEnemy scoreGame;//Créer la référence pour modifier le score jr
   



    private void Awake()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager");
        UI = GameObject.FindGameObjectWithTag("Interface").GetComponent<Interface>();
        //scoreGame = gManager.GetComponent<SpawnEnemy>();
    }
    void OnCollisionEnter2D(Collision2D collision)//Quand le joueur entre en collision
    {
        if (collision.gameObject.tag == "bullet" )//Si la collision est une balle
        {
            UI.SetScoreEnemy();//Augmente le score du joueur
            vie--;//Perd un de vie   
        }
    }
    private void Update()
    {
        if (vie <= 0)//Si l'ennemi n'a plus de vie
        {
            //Potentiellement une anim ?
            Destroy(gameObject);//Détruit l'ennemi
            nbrKillEnemy++;
        }
    }
}
