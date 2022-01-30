using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAllies : MonoBehaviour
{
    [SerializeField]//permet d'accéder à la variable dans l'éditeur tout en là laissant privée
    private float spawnRadius = 7;//Rayon d'apparition des alliés,
    private float timeA; //temps entre l'apparation des alliés

    private Health playerHealth;//Crée la référence au script Health du joueur
    private GameObject[] allies;//Déclare la liste des alliés à spawner (il y avait 2 types d'alliés avant)
    public GameObject player; //Référence au joueur 
    public GameObject Ally1;//Référence à l'allié

    // Start is called before the first frame update
    void Start()
    {
        timeA = 2.5f;
        playerHealth = player.GetComponent<Health>();
        allies = new GameObject[] { Ally1 };
        StartCoroutine(SpawnAnAlly());//Lance le spawn d'allié pour la première fois
    }

    public void UpdateSpawnerA()//Pour plus d'opti au lieu de fixedUpdate créer et appeler cette fonction à chaque fois que le joueur perd/gagne un hp
    {
        if (playerHealth.getCurrentHealth() < 3)
        {
            timeA = 2f;//Change le délaire entre les spawns à 3s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caractéristiques du spawner
        else if (playerHealth.getCurrentHealth() >= 3 && playerHealth.getCurrentHealth() < 5) 
        {
            timeA = 3f;//Change le délai entre les spawns à 3s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caractéristiques du spawner
        else if (playerHealth.getCurrentHealth() >= 5 && playerHealth.getCurrentHealth() < 10)
        {
            timeA = 4f;//Change le délai entre les spawns à 4s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caractéristiques du spawner
        else if (playerHealth.getCurrentHealth() > 10) 
        {
            timeA = 5f;//Change le délai entre les spawns à 5s
        }
    }

    //Fonction spawnant les alliés
    IEnumerator SpawnAnAlly()
    {
        Vector2 spawnPos = player.transform.position; //Récupère la position du joueur
        /*Choisis une coordonnée dans un cercle autour du joueur, multipliée par spawnRadius pour que 
        l'allié n'apparaisse pas au contact du joueur*/
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        /*Fait apparaitre un allié choisis aléatoirement dans la liste,
         à la position choisie avant*/
        Instantiate(allies[Random.Range(0, allies.Length)], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(timeA);//Attends un délai avant de rappeler la fonction
        BufferAlly();//Appel de la méthode tampon
    }

    /*Méthode qui sert de tampon évitant que la coroutine SpawnAnEnnemy tourne en continue
    permettant ainsi de changer les valeurs des variables utilisées dans la coroutine 
    pendant le laps de temps durant lequel elle est à l'arrêt*/
    private void BufferAlly()
    {
        StartCoroutine(SpawnAnAlly());//Relance la coroutine
    }
}
