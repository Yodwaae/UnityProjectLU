using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsGame()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

}
