using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroide : MonoBehaviour
{
    [Header("Asteroide")]
    public GameObject hazardPrefab;

    public Vector2 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    void Start()
    {
        StartCoroutine(SpawnNaves());
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
        }
    }
}
