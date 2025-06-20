using System.Collections.Generic;
using UnityEngine;


public class GameManagerController : MonoBehaviour
{
    public PlayerController playerController;
    public PowerUpController powerUpController;
    public float spawnTimer;
    public float spawnDelay;
    public float massBurnerSpawnTimer;
    public float massBurnerSpawnDelay;
    public GameObject growSnakeCollectible;
    public GameObject massBurnerCollectible;
    public List<Vector2Int> spawnPositions;
    public int totalFruit;
    public int totalMassBurner;
    public float destroyTimer;
    public float destroyDelay = 100;
    public List<GameObject> fruits = new List<GameObject>();
    public List<GameObject> massBurner = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnFood();
        SpawnMassBurner();
        powerUpController.SpawnPowerUps();
    }

    private void SpawnFood()
    {
        spawnTimer += Time.deltaTime;
        destroyTimer += Time.deltaTime;

        if (fruits.Count > 4)
        {
            return;
        }
        

        if (spawnTimer > spawnDelay)
        {
            spawnTimer = 0;
            Vector2Int position = spawnPositions[Random.Range(0, spawnPositions.Count)];
            GameObject newFruit = Instantiate(growSnakeCollectible, new Vector3(position.x, position.y, 0), Quaternion.identity);

            fruits.Add(newFruit);
        }

        if (destroyTimer > destroyDelay)
        {
            destroyTimer = 0;
            Destroy(gameObject);
            //destroyanimation
        }
    }

    private void SpawnMassBurner()
    {
        
        if (playerController.snakeParts.Count < 5)
        {
            return;
        }

        if (massBurner.Count > 2 )
        {
            return;
        }
        massBurnerSpawnTimer += Time.deltaTime;
        if (massBurnerSpawnTimer > massBurnerSpawnDelay)
        {
            massBurnerSpawnTimer = 0;
            Vector2Int position = spawnPositions[Random.Range(0, spawnPositions.Count)];
            GameObject newMassBurner = Instantiate(massBurnerCollectible, new Vector3(position.x, position.y, 0), Quaternion.identity);
            
            massBurner.Add(newMassBurner);
        }
    }
}
