using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public string levelToLoad;
    public GameObject settingsWindow;

    private new AudioSource audio;

    private void Start()
    {
        //charge l'audio
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        audio.Play();//joue le son de lampe des touches des menus
        SceneManager.LoadScene(4);//charge la scene du chargement (transition)
    }

    public void SettingsGame()
    {
        GetComponent<RebindSaveLoad>().Load();//appelle les touches actuelles
        audio.Play();//joue le son de lampe des touches des menus
        settingsWindow.SetActive(true);//affiche les options
    }

    public void CloseSettingsGame()
    {
        audio.Play();//joue le son de lampe des touches des menus
        settingsWindow.SetActive(false);//n'affiche plus les options
        GetComponent<RebindSaveLoad>().Save();//sauvegarde les touches actuelles
    }

    public void Credit()
    {
        audio.Play();//joue le son de lampe des touches des menus
        SceneManager.LoadScene(3);//charge la scene des crédits
    }

    public void QuitGame()
    {
        audio.Play();//joue le son de lampe des touches des menus
        Application.Quit();//quitte l'application
    }
}
