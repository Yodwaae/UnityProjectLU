using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAllies : MonoBehaviour
{
    [SerializeField]//permet d'acc?der ? la variable dans l'?diteur tout en l? laissant priv?e
    private float spawnRadius = 7;//Rayon d'apparition des alli?s,
    private float timeA; //temps entre l'apparation des alli?s

    private Health playerHealth;//Cr?e la r?f?rence au script Health du joueur
    private GameObject[] allies;//D?clare la liste des alli?s ? spawner (il y avait 2 types d'alli?s avant)
    public GameObject player; //R?f?rence au joueur 
    public GameObject Ally1;//R?f?rence ? l'alli?

    // Start is called before the first frame update
    void Start()
    {
        timeA = 2.5f;
        playerHealth = player.GetComponent<Health>();
        allies = new GameObject[] { Ally1 };
        StartCoroutine(SpawnAnAlly());//Lance le spawn d'alli? pour la premi?re fois
    }

    public void UpdateSpawnerA()//Pour plus d'opti au lieu de fixedUpdate cr?er et appeler cette fonction ? chaque fois que le joueur perd/gagne un hp
    {
        if (playerHealth.getCurrentHealth() < 3)
        {
            timeA = 2f;//Change le d?laire entre les spawns ? 3s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caract?ristiques du spawner
        else if (playerHealth.getCurrentHealth() >= 3 && playerHealth.getCurrentHealth() < 5) 
        {
            timeA = 3f;//Change le d?lai entre les spawns ? 3s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caract?ristiques du spawner
        else if (playerHealth.getCurrentHealth() >= 5 && playerHealth.getCurrentHealth() < 10)
        {
            timeA = 4f;//Change le d?lai entre les spawns ? 4s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caract?ristiques du spawner
        else if (playerHealth.getCurrentHealth() > 10) 
        {
            timeA = 5f;//Change le d?lai entre les spawns ? 5s
        }
    }

    //Fonction spawnant les alli?s
    IEnumerator SpawnAnAlly()
    {
        Vector2 spawnPos = player.transform.position; //R?cup?re la position du joueur
        /*Choisis une coordonn?e dans un cercle autour du joueur, multipli?e par spawnRadius pour que 
        l'alli? n'apparaisse pas au contact du joueur*/
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        /*Fait apparaitre un alli? choisis al?atoirement dans la liste,
         ? la position choisie avant*/
        Instantiate(allies[Random.Range(0, allies.Length)], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(timeA);//Attends un d?lai avant de rappeler la fonction
        BufferAlly();//Appel de la m?thode tampon
    }

    /*M?thode qui sert de tampon ?vitant que la coroutine SpawnAnEnnemy tourne en continue
    permettant ainsi de changer les valeurs des variables utilis?es dans la coroutine 
    pendant le laps de temps durant lequel elle est ? l'arr?t*/
    private void BufferAlly()
    {
        StartCoroutine(SpawnAnAlly());//Relance la coroutine
    }
}
