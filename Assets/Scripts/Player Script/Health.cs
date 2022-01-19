using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    public GameObject gManager;//Créer la référence au GameManager
    private SpawnAllies allySpawner;//Créer la référence au spawner allié
    public UnityEngine.Experimental.Rendering.Universal.Light2D lightPlayer;

    private int currentHealth = 5;//Créer la variable de vie du joueur

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

            Destroy(collision.gameObject);//Détruit l'ennemi (à remplacer par une anime puis détruire, comme pour les balles)
            /*Important de détruire l'objet tout de suite ou le joueur perd plusieurs hp avec le même ennemi
            Pour l'animation on pourra donc juste instantiate un objet qui est une animation , qui se détruit elle même une fois finis
            (mettre un Destroy(gameObject, XXf) dans le Start/Awake)*/
            allySpawner.UpdateSpawnerA();////Apelle l'update Spawner quand le joueur perd de la vie plutôt quà chaque frame
            //diminue la taille du halo lorsque le joueur a touché un ennemi
            lightPlayer.pointLightOuterRadius -= 1;
            lightPlayer.pointLightInnerRadius -= 1;
        }
        else if (collision.gameObject.tag == "Ally")//Si la collision est un allié simple
        {
            if(currentHealth < 10) //pour éviter que la vie soit supérieur à la barre de vie
            {
                currentHealth++;//Gagne un point de vie
                healthBar.SetHealth(currentHealth);//fait augmenter la barre de vie
            }

            Destroy(collision.gameObject);//détruit l'allié
            allySpawner.UpdateSpawnerA();//Apelle l'update Spawner quand le joueur gagne de la vie plutôt quà chaque frame
            //augmente la taille du halo lorsque le joueur a touché un allié
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

    public int getCurrentHealth()//Méthode pour récuperer la vie du joueur dans le script SpawnAllies
    {
        return currentHealth;
    }
}
