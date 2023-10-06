using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnpoint;
    public GameObject prefab;
    public float spawnrate;

    private bool shouldSpawn = true;
    private Coroutine spawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemies()
    {
        while (shouldSpawn)
        {
            int randomSpawnPoint = Random.Range(0,spawnpoint.Length);

            GameObject newEnemy = Instantiate(prefab,spawnpoint[randomSpawnPoint].position,Quaternion.identity);

            yield return new WaitForSeconds(spawnrate);
        }
    }
}
