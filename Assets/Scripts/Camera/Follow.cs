using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    private Transform playerPos;//Variable qui va servir à stocker la pos du joueur
    private Camera cam;

    private void Awake()
    {
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
        Debug.Log(ratio);
        /*Limite du terrain, permet de décentrer la camera du joueur quand il arrive au bord du terrain
         evitant que la camera filme du vide qui ne fait pas partie de l'espace de jeu*/
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.5f, 1.3f), Mathf.Clamp(transform.position.y, -5f, 5f), -10);
    }
}
