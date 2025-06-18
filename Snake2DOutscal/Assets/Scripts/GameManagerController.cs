using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public float spawnTimer;
    public float spawnDelay;
    //public float massBurnerSpawnTimer;
  //  public float massBurnerSpawnDelay;
    public GameObject growSnakeCollectible;
    public GameObject massBurnerCollectible;
    public List<Transform> spawnPositions = new List<Transform>();
    public int totalFruit;
    public int totalMassBurner;
    public List<GameObject> fruits = new List<GameObject>();
    public List<GameObject> massBurner = new List<GameObject>();

    public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnFood();
        SpawnMassBurner();
    }

    private void SpawnFood()
    {
        spawnTimer += Time.deltaTime;

        if (fruits.Count > 4)
        {
            return;
        }
        

        if (spawnTimer > spawnDelay)
        {
            spawnTimer = 0;
            GameObject newFruit = Instantiate(growSnakeCollectible, spawnPositions[Random.Range(0, spawnPositions.Count)]);
            fruits.Add(newFruit);
        }
    }

    private void SpawnMassBurner()
    {
        if (playerController.snakeParts.Count < 5)
        {
            return;
        }

        if (massBurner.Count > 3 )
        {
            return;
        }

        if (spawnTimer > spawnDelay)
        {
            spawnTimer = 0;
            GameObject newMassBurner = Instantiate(massBurnerCollectible, spawnPositions[Random.Range(0,spawnPositions.Count)]);
            massBurner.Add(newMassBurner);
        }
    }
}
