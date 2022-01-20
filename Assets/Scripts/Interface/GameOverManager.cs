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
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
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

        //gameOverUI.SetActive(true); //affiche l'écran de GameOver

        //NE MARCHE PAS ET CRÉER PLEIN D'ERREURS
        //Ne s'affiche pas car GameOverMenu est caché
        //TestX s'ajouter à la suite les uns des autres
        //IDÉE SOLUTION : Créer une nouvelle scène qui se charge quand le joueur à 0 PV.
        scoreKillAllies.text = " Score allie : " + PlayerPrefs.GetInt("countScoreAlly").ToString(); //récupère le score du nombre d'alliés tués (vois Interface.cs)
        scoreKillEnemies.text = " Score ennemis : " + PlayerPrefs.GetInt("countScoreEnemy").ToString(); //récupère le score du nombre d'ennemis tués (vois Interface.cs)
        time.text = " testT";
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Game"); //recharge la scène
        //remets les scores Alliés et Ennemis à 0 :
        PlayerPrefs.SetInt("countScoreEnemy", 0);
        PlayerPrefs.SetInt("countScoreAlly", 0);
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
