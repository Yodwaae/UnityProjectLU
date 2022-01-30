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
        //Référence le GameManager et son script SpawnEnemy
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        spawnEnemy = gameManager.GetComponent<SpawnEnemy>();
    }

    public void SetScoreEnemy()
    {
        countScoreEnemy += 10;//Ajoute 10 au score à chaque fois la fonction est appelée
        PlayerPrefs.SetInt("countScoreEnemy", countScoreEnemy); //Enregistre le nombre d'ennemis tués afin de passer la valeur au GameOverManager
        scoreEnemy.text = "Ennemis : " + countScoreEnemy.ToString();// Met à jour le texte de score

        //Mise à jour des spawn des ennemis
        spawnEnemy.UpdateSpawnerE(countScoreEnemy);//Appelle l'update Spawner quand le score est mis à jour plutôt que à chaque frame
    }
    public void SetScoreAlly()
    {
        countScoreAlly --;//Met à jour le nombre d'allié tué (le score est négatif car le but est de tuer le moins d'allié possible
        PlayerPrefs.SetInt("countScoreAlly", countScoreAlly); //Enregistre le nombre d'alliés tués afin de passer la valeur au GameOverManager
        scoreAlly.text = "Alliés : " + countScoreAlly.ToString();// Met à jour le texte de score
    }
}
