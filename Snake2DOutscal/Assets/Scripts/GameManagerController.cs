using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public float spawnTimer;
    public float spawnDelay;
    public GameObject growSnakeCollectible;
    public List<Transform> spawnPositions = new List<Transform>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnFood()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnDelay)
        {
            spawnTimer = 0;
            Instantiate(growSnakeCollectible, spawnPositions[Random.Range(0, spawnPositions.Count)]);
        }
    }
}
