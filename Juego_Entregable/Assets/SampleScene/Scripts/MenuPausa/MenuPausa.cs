using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    public TextMeshProUGUI scoreText;
    private bool juegoPausado = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Continuar();
            }
            else
            {
                Pausa();
            }
        }
    }
    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        scoreText.gameObject.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void Continuar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        scoreText.gameObject.SetActive(true);
        menuPausa.SetActive(false);
    }
    public void Reiniciar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
