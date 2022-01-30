using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist; //cr�ation d'une playlist
    public AudioSource audioSource;
    private int musicIndex = 0;


    void Start()
    {
        audioSource.clip = playlist[0]; //joue la premi�re musique de la playlist par d�faut
        audioSource.Play();
    }

    void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length; //est ce qu'on joue la musique suivante ou est ce qu'on recommence la playlist ?
        audioSource.clip = playlist[musicIndex];//charge la musique choisie
        audioSource.Play();//joue la musique charg�e
    }
}
