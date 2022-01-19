using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI; //plus utile ?
    public static GameOverManager instance;

    public Text time;
    public Text scoreKillAllies;
    public Text scoreKillEnemies;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la sc�ne");
            return;
        }

        instance = this;
    }

    public void onPlayerDeath()
    {
        SceneManager.LoadScene("GameOverScreen");
        //gameOverUI.SetActive(true); //affiche l'�cran de GameOver

        //NE MARCHE PAS ET CR�ER PLEIN D'ERREURS
        //Ne s'affiche pas car GameOverMenu est cach�
        //TestX s'ajouter � la suite les uns des autres
        //ID�E SOLUTION : Cr�er une nouvelle sc�ne qui se charge quand le joueur � 0 PV.
        scoreKillAllies.text += " testA";
        scoreKillEnemies.text += " testE";
        time.text += " testT";
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //recharge la sc�ne
        //gameOverUI.SetActive(false);  //n'affiche plus l'�cran de GameOver
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main_menu"); //charge la sc�ne du menu principal
        //gameOverUI.SetActive(false);  //n'affiche plus l'�cran de GameOver
    }

    public void QuitButton()
    {
        Application.Quit(); // quitte le jeu
    }
}
