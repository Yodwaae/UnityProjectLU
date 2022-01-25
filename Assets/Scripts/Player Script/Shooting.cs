using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;//R�f�rence au firePoint (point de d�part de la balle)
    public GameObject bullet;//R�f�rence � l'objet balle

    private PlayerControls playerInputActions;

    /*Cr�e la variable qui stock le d�lai entre les tirs de l'arme,
     * 0.4 pour l'arme de base, XX pour le fusil d'assaut, XX pour le fusil � pompe, XX pour la mitrailleuse*/
    private float fireRate;
    private int weaponEquipped;//Arme actuelle du joueur( 0 = arme de base, 1 = fusil d'assaut, 2 = fusil � pompe et 3 = mitrailleuse)
    private float bulletSpeed;//Cr�e la variable responsable de la vitesse de la balle
    private float fireDelay;//Cr�e la variable qui sert � calculer le d�lais entre les tirs
    private int amunitions;//Cr�e la variable qui stock les munitions du joueurs
    public MunitionBar munitionBar;
    private Transform weaponChild;

    public AudioSource audioSource;
    public AudioClip fire1;
    public AudioClip fire2;
    public AudioClip fire3;


    void Awake()
    {
        //Pr�pare les contr�les
        playerInputActions = new PlayerControls();
        playerInputActions.basic.Enable();

        fireDelay = 0;//Initalise fireDelay
        weaponEquipped = 0;//( 0 = arme de base, 1 = fusil d'assaut, 2 = fusil � pompe et 3 = mitrailleuse)
        fireRate = 0.4f;//0.4 pour l'arme de base, XX pour le fusil d'assaut, XX pour le fusil � pompe, XX pour la mitrailleuse
        bulletSpeed = 8f;//Initialise bulletSpeed
        amunitions = 100;//Initialise le nb de balles du joueur (attention, correspond � la d�cr�mentation de la bar de munition
        munitionBar.SetMaxMunition(amunitions);//initialise la bar de munition
    }

    // Update is called once per frame
    void Update()//R�cup�re les Inputs
    {
        //Si le jeu est en pause, on ne permet pas au joueur de tirer
        if(PauseMenu.gameIsPaused)
        {
            return;
        }

        /*Enregistre l'input de tir seulement si le joueur poss�de au moins une balle*/
        if (amunitions > 0)
        {
            /*Si l'arme �quip�e n'est pas automatique, r�cup�re un input par clic*/
            if (weaponEquipped == 0 || weaponEquipped == 1 || weaponEquipped == 2)
            {
                /*La premi�re partie de l'expression v�rifie que l'input de tir soit donn�
                 la deuxi�me partie de l'expression v�rifie que Time.time (le temps actuel) soit sup�rieur � fireDelay */


                //if (Input.GetButtonDown("Fire1") && Time.time > fireDelay)
                if (playerInputActions.basic.Fire.ReadValue<float>() == 1 && Time.time > fireDelay)
                {
                    /*Time.time = temps actuel + fireRate = d�lai (en seconde) entre deux tir
                    fireDelay = temps � partir duquel sera autoris� le prochain coup de feu*/
                    fireDelay = Time.time + fireRate;
                    if (weaponEquipped == 0) ShootWP1(); //Si arme basique �quip�e appelle la fonction de tir 1
                    else if (weaponEquipped == 1) ShootWP2();//Si fusil d'assaut �quip� apelle la fonction de tir 2
                    else ShootWP3();//Si fusil � pompe �quip� apelle la fonction de tir 3
                }

            }
            else/*Si l'arme �quip�e est automatique r�cup�re un input en continu*/
            {
                /*La premi�re partie de l'expression v�rifie que l'input de tir soit donn�
                 la deuxi�me partie de l'expression v�rifie que Time.time (le temps actuel) soit sup�rieur � fireDelay */
                if (playerInputActions.basic.Fire.ReadValue<float>() == 1 && Time.time > fireDelay)
                {
                    /*Time.time = temps actuel + fireRate = d�lai (en seconde) entre deux tir
                    fireDelay = temps � partir duquel sera autoris� le prochain coup de feu*/
                    fireDelay = Time.time + fireRate;
                    ShootWP4();//Apelle la fonction de tir 4
                }
            }
        }
    }

    void Shoot(GameObject bulletToFire, Transform firePoint, Vector3 offsetp)//Fonction appel�e lors de l'input de tir
    {  
        /*Cr�e une instance de balle et la range dans une variable, afin de la modifier apr�s*/
        GameObject bulletInst = Instantiate(bullet, firePoint.position + offsetp, firePoint.rotation);
        //R�cup�re le corps de la balle  et le range dans une variable afin de le modifier apr�s
        Rigidbody2D rb = bulletInst.GetComponent<Rigidbody2D>();
        //Ajouter une force de type Impulse, �gale � la vitesse de la balle et dans la direction du up vector de la balle
        //au corps de la balle

        //sens de la trajectoire de la balle en fonction de la direction du personnage
        if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            rb.AddForce(firePoint.up * bulletSpeed * -1, ForceMode2D.Impulse);
        }
        else if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            rb.AddForce(firePoint.up * bulletSpeed * 1, ForceMode2D.Impulse);
        }
    }

    void ShootWP1()//Fonction de tir de l'arme de base
    {
        //tire une balle
        Shoot(bullet, firePoint.transform, new Vector3(0,0,0));
        SoundFire(fire1);
        Debug.Log("Pistolet classique : " + amunitions);
        amunitions -= 4;//d�cremente les munitions de l'arme
        munitionBar.SetMunition(amunitions);//MAJ de la barre de munition
    }
    void ShootWP2()//Fonction de tir du fusil d'assaut
    {
        /*Tire une rafale de trois balles avec un d�lai de 0.1 entre chaque balles
         Les deux derni�res balles sont l�gerement d�sax�es*/
        IEnumerator TimeDelay()
        {
            //yield return new WaitForSeconds(0.1f);
            Shoot(bullet, firePoint.transform,new Vector3(0, 0, 0));
            SoundFire(fire3);

            yield return new WaitForSeconds(0.1f);
            Shoot(bullet, firePoint.transform, new Vector3(.2f, 0, 0));
            SoundFire(fire3);

            yield return new WaitForSeconds(0.1f);
            Shoot(bullet, firePoint.transform,new Vector3(-.2f, 0, 0));
            SoundFire(fire3);
        }

        StartCoroutine(TimeDelay());
        Debug.Log("Fusil d'assaut : " + amunitions);
        amunitions -= 8;//d�cr�mente les munitions de l'arme
        munitionBar.SetMunition(amunitions);//MAJ de la barre de munition
    }

    void ShootWP3()//Fonction de tir du fusil � pompe
    {
        //Tire quatre balle simultan�ment (penser � mettre des angles diff�rents)
        Shoot(bullet, firePoint.transform, new Vector3(0, 0, 0));
        Shoot(bullet, firePoint.transform, new Vector3(0, 0, 0));
        Shoot(bullet, firePoint.transform, new Vector3(0, 0, 0));
        Shoot(bullet, firePoint.transform, new Vector3(0, 0, 0));
        SoundFire(fire2);

        Debug.Log("Fusil � pompe : " + amunitions);
        amunitions -= 12;//d�cr�mente les munitions de l'arme
        munitionBar.SetMunition(amunitions);//MAJ de la barre de munition
    }

    void ShootWP4()//Fonction de tir de la mitrailleuse
    {
        //Tire une balle avec un spread random (entre -.2f et .2f)
        Shoot(bullet, firePoint.transform, new Vector3(Random.Range(-.2f, .2f), 0, 0));
        SoundFire(fire3);
        Debug.Log("Mitrailleuse : " + amunitions);
        amunitions -= 4;//d�cr�mente les munitions de l'arme
        munitionBar.SetMunition(amunitions);//MAJ de la barre de munition
    }

    //Changement de couleur TEMPORAIRE pour TEST
    public void changeWeapon(float bSpd, float fRate, int weapon, int amun, Sprite weaponSprite, Color weaponColor)
    {
        bulletSpeed = bSpd;
        fireRate = fRate;
        weaponEquipped = weapon;
        amunitions = amun;
        munitionBar.SetMunition(amunitions);//MAJ de la barre de munition
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = weaponSprite;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = weaponColor;//Changement de couleur TEMPORAIRE pour TEST
    }

    public void SoundFire(AudioClip audioFire)
    {
        audioSource.PlayOneShot(audioFire);
    }

    /*PS : pour des raisons de praticit� concernant la gestion de la barre de munition, la quantit� de munition est de 100 pour toutes les armes MAIS les armes
    ne se d�charchent pas � la m�me vitesse et 1 balle dans le jeu repr�sente 100/x avec x le nombre que l'on retire � la variable amunitions.*/
}
