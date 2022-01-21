using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    private GameObject gameManager;
    //private MainMenu menu;
    //public Object menu;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
                Resume();
            else
                Paused();
        }
    }

    void Paused()
    {
        pauseMenuUI.SetActive(true); //affiche l'�cran de la pause
        Time.timeScale = 0; //arr�t du temps (le jeu ne se joue pas en fond)
        gameIsPaused = true; //Change le statut du jeu : en pause
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false); //n'affiche plus l'�cran de la pause
        Time.timeScale = 1; //on red�marre le temps
        gameIsPaused = false; //Change le statut du jeu : se joue
    }

    public void LoadMainMenu()
    {
        Resume(); //pour �viter que la procchaine partie qu'on relance soit en �tat de pause
        SceneManager.LoadScene(0); //on utilise l'index de la sc�ne � charger plut�t que son nom car la sc�ne MainMenu se trouve avant le game dans le build
    }
}