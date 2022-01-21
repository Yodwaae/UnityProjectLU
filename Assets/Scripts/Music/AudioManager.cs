using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0]; //joue la première musique de la playlist par défaut
        audioSource.Play();
    }

    // Update is called once per frame
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
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
}
