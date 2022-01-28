using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;

    private new AudioSource audio;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        audio.Play();
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsGame()
    {
        GetComponent<RebindSaveLoad>().Load();
        audio.Play();
        settingsWindow.SetActive(true);
    }


   
    public void CloseSettingsGame()
    {
        audio.Play();
        settingsWindow.SetActive(false);
        GetComponent<RebindSaveLoad>().Save();
    }

    public void QuitGame()
    {
        audio.Play();
        Application.Quit();
    }
}
