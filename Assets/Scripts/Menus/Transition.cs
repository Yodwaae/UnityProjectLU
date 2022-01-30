using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 2.4f;

    // Update is called once per frame
    void Update()
    {
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        //animation du chargement
        transition.SetTrigger("Start");
        //attentque l'animation se fasse
        yield return new WaitForSeconds(transitionTime);
        //charge la scène du jeu
        SceneManager.LoadScene(1);
    }
}
