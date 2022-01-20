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
        countScoreEnemy += 10;//Ajoute 10 au score à chaque fois la fonction est appelée
        PlayerPrefs.SetInt("countScoreEnemy", countScoreEnemy); //Enregistre le nombre d'ennemis tués afin de passer la valeur au GameOverManager
        //C'est un peu brut mais de toute façon le score a pas besoin d'être hyper développé
        scoreEnemy.text = "Ennemis : " + countScoreEnemy.ToString();// Met à jour le texte de score

        //Mise à jour des spawn des ennemis
        spawnEnemy.UpdateSpawnerE(countScoreEnemy);//Appelle l'update Spawner quand le score est mis à jour plutôt que à chaque frame
    }
    public void SetScoreAlly()
    {
        countScoreAlly --; //A VOIR POUR AMÉLIORER COMPTE
        PlayerPrefs.SetInt("countScoreAlly", countScoreAlly); //Enregistre le nombre d'alliés tués afin de passer la valeur au GameOverManager

        scoreAlly.text = "Alliés : " + countScoreAlly.ToString();// Met à jour le texte de score
    }
}
