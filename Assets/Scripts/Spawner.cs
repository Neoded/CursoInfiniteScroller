using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    private int spawnCount;

    [SerializeField] GameObject[] prefabs;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] float minSpawnTime;
    [SerializeField] float maxH = 6f;
    [SerializeField] float minH = 0.2f;
    [SerializeField] float decreaseAmount;
    [SerializeField] int decreaseInterval = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], GetRandomPosition(), Quaternion.identity);
            
            spawnCount++;
            DecreaseSpawnTime();
            

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private Vector2 GetRandomPosition()
    {
        float randomHeight = Random.Range(minH, maxH);
        return new Vector2(transform.position.x, randomHeight);
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }

    private void DecreaseSpawnTime()
    {
        if (spawnCount % decreaseInterval == 0 && spawnTime > minSpawnTime)
        {
            spawnTime -= decreaseAmount;
        }
    }
}
