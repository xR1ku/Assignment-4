using UnityEngine;
using System.Collections;

public class MoleSpawner : MonoBehaviour
{
    public GameObject molePrefab;
    public float spawnInterval = 2f;
    public float minSpawnInterval = 0.5f;
    public float maxLifetime = 2f;
    private Score score;

    void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
        StartCoroutine(SpawnMoles());
    }

    IEnumerator SpawnMoles()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnInterval, spawnInterval + 1f));
            SpawnMole();
            AdjustDifficulty();
        }
    }

    void SpawnMole()
    {
        GameObject mole = Instantiate(molePrefab, GetRandomPosition(), Quaternion.identity);
        Destroy(mole, maxLifetime);
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(0f, Screen.width);
        float y = Random.Range(0f, Screen.height);
        return new Vector3(x, y, 0f);
    }

    void AdjustDifficulty()
    {
        if (spawnInterval > minSpawnInterval)
        {
            spawnInterval -= 0.1f;
            maxLifetime -= 0.1f;
        }
    }
}
