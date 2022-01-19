using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    public GameObject gManager;//Cr�er la r�f�rence au GameManager
    private SpawnAllies allySpawner;//Cr�er la r�f�rence au spawner alli�
    public UnityEngine.Experimental.Rendering.Universal.Light2D lightPlayer;

    private int currentHealth = 5;//Cr�er la variable de vie du joueur

    public HealthBar healthBar;

    private void Awake()
    {
        allySpawner = gManager.GetComponent<SpawnAllies>();
    }

    void Start()
    {
        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)//Quand le joueur entre en collision
    {
        if (collision.gameObject.tag == "Enemy")//Si la collision est un ennemi
        {
            currentHealth --;//Perd un point de vie
            healthBar.SetHealth(currentHealth); //fait diminuer la barre de vie

            Destroy(collision.gameObject);//D�truit l'ennemi (� remplacer par une anime puis d�truire, comme pour les balles)
            /*Important de d�truire l'objet tout de suite ou le joueur perd plusieurs hp avec le m�me ennemi
            Pour l'animation on pourra donc juste instantiate un objet qui est une animation , qui se d�truit elle m�me une fois finis
            (mettre un Destroy(gameObject, XXf) dans le Start/Awake)*/
            allySpawner.UpdateSpawnerA();////Apelle l'update Spawner quand le joueur perd de la vie plut�t qu� chaque frame
            //diminue la taille du halo lorsque le joueur a touch� un ennemi
            lightPlayer.pointLightOuterRadius -= 1;
            lightPlayer.pointLightInnerRadius -= 1;
        }
        else if (collision.gameObject.tag == "Ally")//Si la collision est un alli� simple
        {
            if(currentHealth < 10) //pour �viter que la vie soit sup�rieur � la barre de vie
            {
                currentHealth++;//Gagne un point de vie
                healthBar.SetHealth(currentHealth);//fait augmenter la barre de vie
            }

            Destroy(collision.gameObject);//d�truit l'alli�
            allySpawner.UpdateSpawnerA();//Apelle l'update Spawner quand le joueur gagne de la vie plut�t qu� chaque frame
            //augmente la taille du halo lorsque le joueur a touch� un alli�
            lightPlayer.pointLightOuterRadius += 1;
            lightPlayer.pointLightInnerRadius += 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            //fin du jeu
            //GameOverManager.instance.onPlayerDeath(); Plus utile ?
            SceneManager.LoadScene("GameOverScreen");
        }
    }

    public int getCurrentHealth()//M�thode pour r�cuperer la vie du joueur dans le script SpawnAllies
    {
        return currentHealth;
    }
}
