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

    //TEST ne marche pas
    //private Interface UI;

    private void Awake()
    {
        /*if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la sc�ne");
            return;
        }

        instance = this;*/

        /*gameManager = GameObject.FindGameObjectWithTag("GameManager");
        UI = gameManager.GetComponent<Interface>();*/
    }

    public void Start()
    {
        onPlayerDeath();
    }

    public void onPlayerDeath()
    {

        //gameOverUI.SetActive(true); //affiche l'�cran de GameOver

        //NE MARCHE PAS ET CR�ER PLEIN D'ERREURS
        //Ne s'affiche pas car GameOverMenu est cach�
        //TestX s'ajouter � la suite les uns des autres
        //ID�E SOLUTION : Cr�er une nouvelle sc�ne qui se charge quand le joueur � 0 PV.
        scoreKillAllies.text = " Score allie : " + PlayerPrefs.GetInt("countScoreAlly").ToString(); //r�cup�re le score du nombre d'alli�s tu�s (vois Interface.cs)
        scoreKillEnemies.text = " Score ennemis : " + PlayerPrefs.GetInt("countScoreEnemy").ToString(); //r�cup�re le score du nombre d'ennemis tu�s (vois Interface.cs)
        time.text = " testT";
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Game"); //recharge la sc�ne
        //remets les scores Alli�s et Ennemis � 0 :
        PlayerPrefs.SetInt("countScoreEnemy", 0);
        PlayerPrefs.SetInt("countScoreAlly", 0);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main_menu"); //charge la sc�ne du menu principal
    }

    public void QuitButton()
    {
        Application.Quit(); // quitte le jeu
    }
}
