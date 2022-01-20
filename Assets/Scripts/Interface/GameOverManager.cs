using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    private GameObject gameManager;

    public Text time;
    public Text scoreKillAllies;
    public Text scoreKillEnemies;


    public void Start()
    {
        onPlayerDeath();
    }

    public void onPlayerDeath()
    {
        scoreKillAllies.text = "Score allie : " + PlayerPrefs.GetInt("countScoreAlly").ToString(); //récupère le score du nombre d'alliés tués (vois Interface.cs)
        scoreKillEnemies.text = "Score ennemis : " + PlayerPrefs.GetInt("countScoreEnemy").ToString(); //récupère le score du nombre d'ennemis tués (vois Interface.cs)
        time.text = "Temps : " + PlayerPrefs.GetString("gameTime"); //récupère le temps de jeu pour l'afficher
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Game"); //recharge la scène

        //remets les scores Alliés, Ennemis et le Temps à 0 :
        PlayerPrefs.SetInt("countScoreEnemy", 0);
        PlayerPrefs.SetInt("countScoreAlly", 0);
        PlayerPrefs.SetInt("gameTime", 0);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main_menu"); //charge la scène du menu principal
    }

    public void QuitButton()
    {
        Application.Quit(); // quitte le jeu
    }
}
