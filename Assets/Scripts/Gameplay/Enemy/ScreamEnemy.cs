using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamEnemy : MonoBehaviour
{
    public AudioClip[] screamPlaylist;
    public AudioSource audioSource;
    private int tirage;

    public void ScreamEnemies()
    {
        tirage = Random.Range(0, 4);
        audioSource.clip = screamPlaylist[tirage]; //joue la musique de la playlist choisie
        audioSource.Play();
    }
}
