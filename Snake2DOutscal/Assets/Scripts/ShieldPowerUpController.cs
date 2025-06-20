using UnityEngine;

public class ShieldPowerUpController : MonoBehaviour
{

    bool isCollected = false;
    public PowerUpController powerUpController;
    private void Start()
    {
        powerUpController = FindFirstObjectByType<PowerUpController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCollected) return;

        isCollected = true;
        PlayerController playerController = collision.GetComponent<PlayerController>();
        playerController.ShieldPowerUp();
        powerUpController.activePowerUps.Remove(gameObject);
        Destroy(gameObject);
    }
}
