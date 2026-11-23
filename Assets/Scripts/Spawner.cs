using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] float maxH = 6f;
    [SerializeField] float minH = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(obstaclePrefab, GetRandomPosition(), Quaternion.identity);
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
}
