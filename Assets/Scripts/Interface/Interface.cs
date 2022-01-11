using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    private SpawnEnemy spawnEnemy;

    private GameObject gameManager;
    public Text scoreEnemy;
    public Text scoreAlly;
    private int countScoreEnemy;
    private int countScoreAlly;
    

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        spawnEnemy = gameManager.GetComponent<SpawnEnemy>();

        Debug.Log(countScoreAlly);
        Debug.Log(countScoreEnemy);
    }

    public void SetScoreEnemy()//Le code est reli� � rien
    {
        countScoreEnemy += 10;//Ajoute 10 au score � chaque fois la fonction est appel�e
        //C'est un peu brut mais de toute fa�on le score a pas besoin d'�tre hyper d�velopp�
        scoreEnemy.text = "Ennemis : " + countScoreEnemy.ToString();// Met � jour le texte de score

        //Mise � jour des spawn des ennemis
        spawnEnemy.UpdateSpawnerE(countScoreEnemy);//Appelle l'update Spawner quand le score est mis � jour plut�t que � charque frame
    }
    public void SetScoreAlly()//Pourquoi un score positif quand on tue des alli�s ?
    {
        countScoreAlly += 10;
        scoreAlly.text = "Alli�s : " + countScoreAlly.ToString();// Met � jour le texte de score
    }
}
