using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Balas")]
    public float speed;
    public Transform shootOrigin;
    public GameObject shootPrefab;
    [Header("Límites de la nave")]
    public float xMin;
    public float xMax;

    private AudioSource audioSource;
    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        //movimiento w,d dinámico para que valga con varios botones
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.z, transform.position.z);
        //Establezco un rango para limitar por donde se mueva el pj
        float x = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(x, 0, 0);
        //Poner un botón para el Shoot tanto para pc, android, etc
        if (Input.GetButtonDown("Shoot"))
        {
            // Se crea la bala cada vez que aplasto espacio con todo y script mover
            Instantiate(shootPrefab, shootOrigin.position, shootOrigin.rotation);
            audioSource.Play();
        }
    }
}
