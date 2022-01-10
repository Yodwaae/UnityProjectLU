using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public SpawnEnemy spawnEnemy;

    public GameObject gameManager;
    public Text scoreEnemy;
    public Text scoreAlly;
    private int countScoreEnemy;
    private int countScoreAlly;
    

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void SetScoreEnemy()
    {
        countScoreEnemy += 10;//Ajoute 10 au score � chaque fois la fonction est appel�e
        //C'est un peu brut mais de toute fa�on le score a pas besoin d'�tre hyper d�velopp�
        scoreEnemy.text = "Ennemis : " + countScoreEnemy.ToString();// Met � jour le texte de score

        //Mise � jour des spawn des ennemis
        spawnEnemy.UpdateSpawnerE();//Appelle l'update Spawner quand le score est mis � jour plut�t que � charque frame
    }
    public void SetScoreAlly()
    {
        countScoreAlly += 10;
        scoreAlly.text = "Alli�s : " + countScoreAlly.ToString();// Met � jour le texte de score
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
