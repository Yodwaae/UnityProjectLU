using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]//permet d'acc�der � la variable dans l'�diteur tout en l� laissant priv�e
    private int vie;//Cr�er la variable de vie de l'ennemi
    private Interface UI; //cr�er la variable r�f�rence � l'interface
    private GameObject gManager;//Cr�er la r�f�rence au GameManager
    private static int nbrKillEnemy;
    public Animator animator;

    //public Sprite spriteDegat;
    //private SpawnEnemy scoreGame;//Cr�er la r�f�rence pour modifier le score jr
    
    private void Start()
    {
        //r�cup�re l'interface
        UI = GameObject.FindGameObjectWithTag("Interface").GetComponent<Interface>();
    }
    void OnCollisionEnter2D(Collision2D collision)//Quand le joueur entre en collision
    {
        if (collision.gameObject.tag == "bullet")//Si la collision est une balle
        {
            UI.SetScoreEnemy();//Augmente le score du joueur
            vie--;//Perd un pont de vie
        }
    }
    private void Update()
    {
        if (vie == 1)
        {
            //change l'animation de l'ennemi en reprennant celle de l'ennemi 1 sans l'armure
            //L'avertissement dans la console vient du fait que l'ennemi1 ne poss�de pas cette variable contrairement 
            //� l'ennemi2
            animator.SetBool("OneLife", true);
        }
        if (vie <= 0)//Si l'ennemi n'a plus de vie
        {
            //Potentiellement une anim ? (non pas le temps XD)
            Destroy(gameObject);//D�truit l'ennemi
            nbrKillEnemy++;//augmente le nombre de kill
        }
    }
}
