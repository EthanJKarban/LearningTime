using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefab;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSeconds = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyFactor = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroyed = new UnityEvent();




    private int currentWave = 1;
    private float timeSinceLastSpawn = 0f;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Awake()
    {
        onEnemyDestroyed.AddListener(EnemyDestroyed);
    }
    private void Start()
    {
        StartCoroutine(StartWave());
    }
    private void Update()
    {
        if (!isSpawning) return; 
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / enemiesPerSeconds) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            Debug.Log("Pull the level Kronk!");
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive <= 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());   
    }
   
    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefab[0];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }
    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyFactor));
    }
}
