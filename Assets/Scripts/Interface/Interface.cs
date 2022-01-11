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

    public void SetScoreEnemy()//Le code est relié à rien
    {
        countScoreEnemy += 10;//Ajoute 10 au score à chaque fois la fonction est appelée
        //C'est un peu brut mais de toute façon le score a pas besoin d'être hyper développé
        scoreEnemy.text = "Ennemis : " + countScoreEnemy.ToString();// Met à jour le texte de score

        //Mise à jour des spawn des ennemis
        spawnEnemy.UpdateSpawnerE(countScoreEnemy);//Appelle l'update Spawner quand le score est mis à jour plutôt que à charque frame
    }
    public void SetScoreAlly()//Pourquoi un score positif quand on tue des alliés ?
    {
        countScoreAlly += 10;
        scoreAlly.text = "Alliés : " + countScoreAlly.ToString();// Met à jour le texte de score
    }
}
