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
        //R�f�rence le GameManager et son script SpawnEnemy
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        spawnEnemy = gameManager.GetComponent<SpawnEnemy>();
    }

    public void SetScoreEnemy()
    {
        countScoreEnemy += 10;//Ajoute 10 au score � chaque fois la fonction est appel�e
        PlayerPrefs.SetInt("countScoreEnemy", countScoreEnemy); //Enregistre le nombre d'ennemis tu�s afin de passer la valeur au GameOverManager
        scoreEnemy.text = "Ennemis : " + countScoreEnemy.ToString();// Met � jour le texte de score

        //Mise � jour des spawn des ennemis
        spawnEnemy.UpdateSpawnerE(countScoreEnemy);//Appelle l'update Spawner quand le score est mis � jour plut�t que � chaque frame
    }
    public void SetScoreAlly()
    {
        countScoreAlly --;//Met � jour le nombre d'alli� tu� (le score est n�gatif car le but est de tuer le moins d'alli� possible
        PlayerPrefs.SetInt("countScoreAlly", countScoreAlly); //Enregistre le nombre d'alli�s tu�s afin de passer la valeur au GameOverManager
        scoreAlly.text = "Alli�s : " + countScoreAlly.ToString();// Met � jour le texte de score
    }
}
