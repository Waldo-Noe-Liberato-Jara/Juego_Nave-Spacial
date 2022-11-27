using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionPlayer;
    [Header("Puntuación")]
    public int scoreValue;
    private GameController gameController;
    void Start(){
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        Instantiate(explosion, transform.position, transform.rotation);
        if(other.CompareTag("Player")){
            Instantiate(explosionPlayer, transform.position, transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
