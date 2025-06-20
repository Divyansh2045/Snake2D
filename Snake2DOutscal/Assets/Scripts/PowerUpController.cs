using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;


public class PowerUpController : MonoBehaviour
{
    public float powerUpDelay;
    public float powerUpTimer;
    public List<GameObject> powerUps = new List<GameObject>();
    public List<Vector2Int> powerUpLocations = new List<Vector2Int>();
    public List<GameObject> activePowerUps = new List<GameObject>();
    private int maxActive = 1;
    [SerializeField] PlayerController playerController;

    public void SpawnPowerUps()
    {
        powerUpTimer += Time.deltaTime;

        if (activePowerUps.Count >= maxActive)
        {
            return;
        }

        if (playerController.snakeParts.Count < 6) return; 
        if (powerUpTimer >= powerUpDelay)
        {
            powerUpTimer = 0f;
            int index = Random.Range(0, powerUpLocations.Count);
            int prefabIndex = Random.Range(0, powerUps.Count);
            GameObject selectedPowerUp = powerUps[prefabIndex];
            Vector2Int spawnPosition = powerUpLocations[Random.Range(0, powerUpLocations.Count)];
            GameObject powerUp = Instantiate(selectedPowerUp, new Vector3(spawnPosition.x, spawnPosition.y, 0), Quaternion.identity);
            activePowerUps.Add(powerUp);
        }

    }
}
