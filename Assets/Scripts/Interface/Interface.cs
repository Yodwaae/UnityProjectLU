using System;
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
    public int countScoreEnemy;
    public int countScoreAlly;


    public bool dontDestroy;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        spawnEnemy = gameManager.GetComponent<SpawnEnemy>();
    }

    public void SetScoreEnemy()
    {
        countScoreEnemy += 10;//Ajoute 10 au score � chaque fois la fonction est appel�e
        PlayerPrefs.SetInt("countScoreEnemy", countScoreEnemy); //Enregistre le nombre d'ennemis tu�s afin de passer la valeur au GameOverManager
        //C'est un peu brut mais de toute fa�on le score a pas besoin d'�tre hyper d�velopp�
        scoreEnemy.text = "Ennemis : " + countScoreEnemy.ToString();// Met � jour le texte de score

        //Mise � jour des spawn des ennemis
        spawnEnemy.UpdateSpawnerE(countScoreEnemy);//Appelle l'update Spawner quand le score est mis � jour plut�t que � chaque frame
    }
    public void SetScoreAlly()
    {
        countScoreAlly --; //A VOIR POUR AM�LIORER COMPTE
        PlayerPrefs.SetInt("countScoreAlly", countScoreAlly); //Enregistre le nombre d'alli�s tu�s afin de passer la valeur au GameOverManager

        scoreAlly.text = "Alli�s : " + countScoreAlly.ToString();// Met � jour le texte de score
    }
}
