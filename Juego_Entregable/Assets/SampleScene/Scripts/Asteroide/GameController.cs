using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Asteroide")]
    public Transform hazardOrigin;
    public GameObject hazardPrefab;

    public Vector2 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    [Header("Puntuación")]
    private int score;
    public TextMeshProUGUI scoreText;
    [Header("Game Over")]
    public TextMeshProUGUI GameOverText;
    private bool gameOver;
    public TextMeshProUGUI RestartText;
    private bool restart;
    public TextMeshProUGUI SalirText;
    private bool salir;
    [SerializeField] private GameObject botonPausa;
    //Silenciar Audio del juego
    [Header("Música")]
    public AudioSource musicGameOver;
    public AudioSource musicLevel;
    public AudioSource musicMenu;

    void Start()
    {
        //MUSICA
        musicLevel.Play();
        //CONTROLES
        gameOver = false;
        GameOverText.gameObject.SetActive(false);
        restart = false;
        RestartText.gameObject.SetActive(false);
        salir = false;
        SalirText.gameObject.SetActive(false);
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnNaves());
    }
    void Update(){
        if(restart && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (restart && Input.GetKeyDown(KeyCode.S))
        {
            Time.timeScale = 0f;
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator SpawnNaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                Instantiate(hazardPrefab, spawPosition, Quaternion.identity);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            //Para acabar con el bucle al perder
            if(gameOver){
                restart = true;
                RestartText.gameObject.SetActive(true);
                salir = true;
                SalirText.gameObject.SetActive(true);
                botonPausa.SetActive(false);
                if(musicLevel.isPlaying){
                    musicLevel.Stop();
                    musicGameOver.Play();
                }else{
                    musicLevel.Play();
                }
                break;
            }
        }
    }
    public void AddScore(int value){
        score += value;
        UpdateScore();
    }
    void UpdateScore(){
        scoreText.text = "Score: "+score;
    }
    public void GameOver(){
        gameOver = true;
        GameOverText.gameObject.SetActive(true);
    }
    public void Silenciar(){
        if(musicLevel.isPlaying){
            musicLevel.Pause();
            musicMenu.Play();
        }else{
            musicLevel.UnPause();
        }
    }
}
