using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public PlayerInput playerInputActions;
    private float input;

    public GameObject pauseMenuUI;
    public GameObject settingsWindow;

    public new AudioSource audio;


    public void Paused(InputAction.CallbackContext ctx)
    {
        if (!gameObject.scene.IsValid())//si la sc?ne n'est pas valide
            return;
        
        if (ctx.performed)
        {
            audio.Play();
            if (gameIsPaused == true)
            {
                //Red?marre le jeu
                Resume();
            }
            else
            {
                //Stoppe le jeu
                Stopped();
            }
        }
    }

    public void Stopped()
    {
        //Mettre de quoi ne pas pouvoir tirer une balle
        pauseMenuUI.SetActive(true); //affiche l'?cran de la pause
        audio.Play(); //joue le son de lampe des touches des menus
        Time.timeScale = 0; //arr?t du temps (le jeu ne se joue pas en fond)
        gameIsPaused = true; //Change le statut du jeu : en pause
    }

    public void Resume()
    {
        //probl?me avec ce bouton
        pauseMenuUI.SetActive(false); //n'affiche plus l'?cran de la pause
        audio.Play(); //joue le son de lampe des touches des menus
        Time.timeScale = 1; //on red?marre le temps
        gameIsPaused = false; //Change le statut du jeu : se joue
    }

    public void OpenSettingsWindow()
    {
        GetComponent<RebindSaveLoad>().Load();//Appelle la fonction Load de script RebindSaveLoad pour charger les touches
        settingsWindow.SetActive(true);//affiche l'?cran des options
        audio.Play(); //joue le son de lampe des touches des menus
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);//n'affiche plus l'?cran des options
        audio.Play(); //joue le son de lampe des touches des menus
        GetComponent<RebindSaveLoad>().Save();//Appelle la fonction Save de script RebindSaveLoad pour save les nouvelles touches
    }

    public void LoadMainMenu()
    {
        Resume(); //pour ?viter que la prochaine partie qu'on relance soit en ?tat de pause
        SceneManager.LoadScene(0); //on utilise l'index de la sc?ne ? charger plut?t que son nom car la sc?ne MainMenu se trouve avant le game dans le build
        audio.Play(); //joue le son de lampe des touches des menus
    }
}