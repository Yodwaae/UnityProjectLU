using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;//Créé une variable pour stocker le corps du joueur
    public PlayerInput playerInputActions;
    private Vector2 inputMovement;
    private float speed = 5f;

    public Animator animator;//Animation
    public SpriteRenderer spriteRenderer;//image
    public Transform firePoint;

    public AudioSource audioSource;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();//Récupère le rigidBody du joueur et le stock dans la variable créée préalablement
    }

    private void Update()
    {
        Vector2 finalMovement = inputMovement * speed * Time.deltaTime;

        rb.transform.Translate(finalMovement);


        Debug.Log(finalMovement);

        //Gestion des animations
        animator.SetFloat("SpeedH", Mathf.Abs(finalMovement.x));
        animator.SetFloat("SpeedV", Mathf.Abs(finalMovement.y));

        //Valeur permettant un flip correct pour le clavier mais aussi pour la manette MARCHE PLUS
        if (finalMovement.x >= 0.05)
            Flip(1);
        else if (finalMovement.x <= -0.05)
            Flip(2);


        //Permet de jouer le bruit des pas du joueur
        if ((finalMovement.x != 0 || finalMovement.y != 0) && audioSource.isPlaying == false)
        {
            audioSource.Play();
        }

        //Limite du terrain, empeche le joueur de dépasse les coordonées spécifiées
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -14f, 14f), Mathf.Clamp(transform.position.y, -14f, 14f));
    }


    //Permet de changer la direction du sprite du joueur, de l'arme et du firePoint
    void Flip(int flip)
    {
        SpriteRenderer sp1 = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        Transform sp2 = gameObject.transform.GetChild(0);

        if (flip == 1)
        {
            spriteRenderer.flipX = true; //joueur
            sp1.flipX = true; //arme
            sp2.transform.localPosition = new Vector3(Mathf.Abs(sp2.transform.localPosition.x), sp2.transform.localPosition.y, sp2.transform.localPosition.z);//firePoint
        }
        else if (flip == 2)
        {
            spriteRenderer.flipX = false; //joueur
            sp1.flipX = false; //arme
            sp2.transform.localPosition = new Vector3(-Mathf.Abs(sp2.transform.localPosition.x), sp2.transform.localPosition.y, sp2.transform.localPosition.z);//firePoint
        }
    }

    public void Walk(InputAction.CallbackContext ctx)
    {
        var inputValue = ctx.ReadValue<Vector2>(); //détecte la touche
        inputMovement = new Vector2(inputValue.x, inputValue.y);
    }


    //------------------------------------------------essai 2 avec PlayerControls()--------------------------------------------------------------------------------
    /*private Rigidbody2D rb;//Créé une variable pour stocker le corps du joueur
    private PlayerControls playerInputActions;
    private float speed = 5f;

    public Animator animator;//Animation
    public SpriteRenderer spriteRenderer;//image
    public Transform firePoint;

    public AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();//Récupère le rigidBody du joueur et le stock dans la variable créée préalablement
        playerInputActions = new PlayerControls();
        playerInputActions.basic.Enable();
    }

    //Déplacement du personnage
    public void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.basic.Move.ReadValue<Vector2>();
        rb.transform.Translate(new Vector2(inputVector.x, inputVector.y) * speed * Time.fixedDeltaTime);

        //Gestion des animations
        animator.SetFloat("SpeedH", Mathf.Abs(inputVector.x));
        animator.SetFloat("SpeedV", Mathf.Abs(inputVector.y));

        //Valeur permettant un flip correct pour le clavier mais aussi pour la manette
        if (inputVector.x >= 0.5)
            Flip(1);
        else if (inputVector.x <= -0.5)
            Flip(2);
    }

    private void Update()
    {
        Vector2 inputVector = playerInputActions.basic.Move.ReadValue<Vector2>();


        //Permet de jouer le bruit des pas du joueur
        if ((inputVector.x != 0 || inputVector.y != 0) && audioSource.isPlaying == false)
        {
            audioSource.Play();
        }

        //Limite du terrain, empeche le joueur de dépasse les coordonées spécifiées
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -14f, 14f), Mathf.Clamp(transform.position.y, -14f, 14f));
    }


    //Permet de changer la direction du sprite du joueur, de l'arme et du firePoint
    void Flip(int flip)
    {
        SpriteRenderer sp1 = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        Transform sp2 = gameObject.transform.GetChild(0);

        if (flip == 1)
        {
            spriteRenderer.flipX = true; //joueur
            sp1.flipX = true; //arme
            sp2.transform.localPosition = new Vector3(Mathf.Abs(sp2.transform.localPosition.x), sp2.transform.localPosition.y, sp2.transform.localPosition.z);//firePoint
        }
        else if (flip == 2)
        {
            spriteRenderer.flipX = false; //joueur
            sp1.flipX = false; //arme
            sp2.transform.localPosition = new Vector3(-Mathf.Abs(sp2.transform.localPosition.x), sp2.transform.localPosition.y, sp2.transform.localPosition.z);//firePoint
        }
    }*/




    //---------------------------------------------------------------ANCIEN SYSTEME DE MOUVEMENT --------------------------------------------------------------------------------------------------------

    /*public float moveSpeed;//Vitesse du joueur
    public Animator animator;//Animation
    public SpriteRenderer spriteRenderer;//image
    public Transform firePoint;

    private Rigidbody2D rb;//Créé une variable pour stocker le corps du joueur
    private Camera cam;//Crée une variable pour stocker la camera
    private Transform rbWp;

    Vector2 movement;//Vecteur contenant le mouvement du joueur
    Vector2 mousePosition;//Vecteur contenant la position de la souris

    public AudioSource audioSource;


    private void Awake()
    {
        rbWp = gameObject.transform.GetChild(1).GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();//Récupère le rigidBody du joueur et le stock dans la variable créée préalablement
        cam = Camera.main;//Récupère la camera et la stock dans la variable créée préalablement
    }

    //Permet de changer la direction du sprite du joueur, de l'arme et du firePoint
    void Flip(float _velocity)
    {
        SpriteRenderer sp1 = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        Transform sp2 = gameObject.transform.GetChild(0);

        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = true; //joueur
            sp1.flipX = true; //arme
            sp2.transform.localPosition = new Vector3(Mathf.Abs(sp2.transform.localPosition.x), sp2.transform.localPosition.y, sp2.transform.localPosition.z);//firePoint
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = false; //joueur
            sp1.flipX = false; //arme
            sp2.transform.localPosition = new Vector3(-Mathf.Abs(sp2.transform.localPosition.x), sp2.transform.localPosition.y, sp2.transform.localPosition.z);//firePoint
        }
    }


    // Update is called once per frame
    void Update()//Récupère les inputs 
    {
        //Récupère les Inputs de mouvement
        movement.x = Input.GetAxisRaw("Horizontal");//Récupère l'input sur l'axe X et le stock dans une variable
        movement.y = Input.GetAxisRaw("Vertical");//Récupère l'input sur l'axe Y et le stock dans une variable

        //Permet de jouer le bruit des pas du joueur
        if((movement.x != 0 || movement.y != 0) && audioSource.isPlaying == false)
        {
            audioSource.Play();
        }

        //Gestion des animations
        animator.SetFloat("SpeedH", Mathf.Abs(movement.x));
        animator.SetFloat("SpeedV", Mathf.Abs(movement.y));

        //Récupère la position de la souris, la transforme en coordonées et la stock dans une variable
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition); //A MODIFIER

        //Limite du terrain, empeche le joueur de dépasse les coordonées spécifiées
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -14f, 14f), Mathf.Clamp(transform.position.y, -14f, 14f));
    }

    void FixedUpdate()//Exécute les inputs
    {
        //Déplace le joueur (position actuelle + direction (normalized élimine l'accélération lors de mouvement en diagonale) * vitesse
        //* deltaTime 
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        Flip(movement.x);

        //ANCIEN SYSTEME D'ORIENTATION
        //Création du vecteur d'orientation de l'arme(position de la souris - position actuelle)
        //Vector2 lookDir = (mousePosition - (Vector2)rbWp.position).normalized;
        //Vector2 lookDirFP = (mousePosition - (Vector2)rbWp.position).normalized;


        ///Transforme le vecteur d'orientation en angle, puis le converti de radiant en degré et compense l'offset
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg+180f;
        //rbWp.rotation = Quaternion.Euler(0,0, angle);//Applique la rotation au joueur

        //float angleFr = Mathf.Atan2(lookDirFP.y, lookDirFP.x) * Mathf.Rad2Deg - 90f;
        //firePoint.rotation = Quaternion.Euler(0, 0, angleFr);
    }*/
}
