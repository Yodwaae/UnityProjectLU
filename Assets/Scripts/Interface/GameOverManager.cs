using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameOverManager instance;

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
        gameOverUI.SetActive(true); //affiche l'écran de GameOver
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //recharge la scène
        gameOverUI.SetActive(false);  //n'affiche plus l'écran de GameOver
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main_menu"); //charge la scène du menu principal
        gameOverUI.SetActive(false);  //n'affiche plus l'écran de GameOver
    }

    public void QuitButton()
    {
        Application.Quit(); // quitte le jeu
    }
}
