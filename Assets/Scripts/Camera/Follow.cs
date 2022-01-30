using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Transform playerPos;//Variable qui va servir à stocker la pos du joueur
    private Camera cam;

    private void Awake()
    {
        //Ancien essai
        //float orthoSize = ground.bounds.size.x * Screen.height / Screen.width * 0.25f;
        //Camera.main.orthographicSize = orthoSize;

        //Trouve l'objet joueur et récupère son composant Transform
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*Fait suivre le mouvement du joueur à la caméra, 
         le -10 en z sert à garder la caméra à la bonne hauteur pour voir le joueur*/
        transform.position = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, -10) ;
        float ratio = (cam.orthographicSize * cam.scaledPixelWidth) / cam.scaledPixelHeight;
        /*Limite du terrain, permet de décentrer la camera du joueur quand il arrive au bord du terrain
         évitant que la camera filme du vide qui ne fait pas partie de l'espace de jeu*/
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-15 + Camera.main.orthographicSize* cam.aspect, 15 - Camera.main.orthographicSize * cam.aspect), Mathf.Clamp(transform.position.y, -15 + Camera.main.orthographicSize, 15 - Camera.main.orthographicSize), -10);
    }
}
