using UnityEngine;
using System.Collections.Generic;

public class SpawnerManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float radius = 5f;
    
    public float spawnInterval = 10f;
    public int maxEnemies = 10;

    private float timer;
    private List<GameObject> enemies = new List<GameObject>();
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemies();
        }
        CleanEnemyList();
        MoveEnemies();
    }

    void SpawnEnemies()
    {
        int amount = Random.Range(1, 6); 
        for (int i = 0; i < amount; i++)
        {
            if (enemies.Count >= maxEnemies)
                return;
            Vector2 randomPos = Random.insideUnitCircle.normalized * radius;
            Vector3 spawnPosition = player.position + new Vector3(randomPos.x, randomPos.y, 0);
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemies.Add(newEnemy);
        }
    }

    void CleanEnemyList()
    {
        // Borra enemigos destruidos para evitar duplicados
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);
        }
    }

    void MoveEnemies()
    {
        foreach (GameObject gameObject in enemies)
        {
            if (gameObject == null) continue;

            Vector3 dir = (player.position - gameObject.transform.position).normalized;
            float speed = 2f;
            gameObject.transform.position += dir * speed * Time.deltaTime;
        }
    }
}
