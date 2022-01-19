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
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;
        }

        instance = this;
    }

    public void onPlayerDeath()
    {
        SceneManager.LoadScene("GameOverScreen");
        //gameOverUI.SetActive(true); //affiche l'écran de GameOver

        //NE MARCHE PAS ET CRÉER PLEIN D'ERREURS
        //Ne s'affiche pas car GameOverMenu est caché
        //TestX s'ajouter à la suite les uns des autres
        //IDÉE SOLUTION : Créer une nouvelle scène qui se charge quand le joueur à 0 PV.
        scoreKillAllies.text += " testA";
        scoreKillEnemies.text += " testE";
        time.text += " testT";
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //recharge la scène
        //gameOverUI.SetActive(false);  //n'affiche plus l'écran de GameOver
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main_menu"); //charge la scène du menu principal
        //gameOverUI.SetActive(false);  //n'affiche plus l'écran de GameOver
    }

    public void QuitButton()
    {
        Application.Quit(); // quitte le jeu
    }
}
