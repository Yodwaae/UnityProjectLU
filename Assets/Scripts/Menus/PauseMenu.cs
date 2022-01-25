using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    private PlayerControls playerInputActions;

    public GameObject pauseMenuUI;
    private GameObject gameManager;
    public GameObject SettingsWindow;

    public new AudioSource audio;

    private void Awake()
    {
        //Pr�pare les contr�les
        playerInputActions = new PlayerControls();
        playerInputActions.basic.Enable();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if(playerInputActions.basic.Paused.ReadValue<float>() == 1)
        {
            audio.Play();
            if (gameIsPaused == true)
                Resume();
            else
                Paused();
        }
    }

    void Paused()
    {
        //Mettre de quoi ne pas pouvoir tirer une balle
        pauseMenuUI.SetActive(true); //affiche l'�cran de la pause
        audio.Play();
        Time.timeScale = 0; //arr�t du temps (le jeu ne se joue pas en fond)
        gameIsPaused = true; //Change le statut du jeu : en pause
    }

    public void Resume()
    {
        //probl�me avec ce bouton
        pauseMenuUI.SetActive(false); //n'affiche plus l'�cran de la pause
        audio.Play();
        Time.timeScale = 1; //on red�marre le temps
        gameIsPaused = false; //Change le statut du jeu : se joue
    }

    public void OpenSettingsWindow()
    {
        SettingsWindow.SetActive(true);
        audio.Play();
    }

    public void CloseSettingsWindow()
    {
        SettingsWindow.SetActive(false);
        audio.Play();
    }

    public void LoadMainMenu()
    {
        Resume(); //pour �viter que la prochaine partie qu'on relance soit en �tat de pause
        SceneManager.LoadScene(0); //on utilise l'index de la sc�ne � charger plut�t que son nom car la sc�ne MainMenu se trouve avant le game dans le build
        audio.Play();
    }
}
