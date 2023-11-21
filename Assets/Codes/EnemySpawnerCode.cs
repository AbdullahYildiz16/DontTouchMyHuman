using UnityEngine;

public class EnemySpawnerCode : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    public float timeBtwSpawns;
    public float startTimeBtwSpawns;

    [SerializeField] Vector3[] spawnRotations;

    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
        InvokeRepeating("spawnEnemy", startTimeBtwSpawns, timeBtwSpawns);

    }

    void spawnEnemy()
    {
        int randPos = Random.Range(0, spawnPoints.Length);
        GameObject currentObject = Instantiate(enemy, spawnPoints[randPos].position, Quaternion.identity);
        currentObject.transform.Rotate(spawnRotations[randPos]);

    }
}
