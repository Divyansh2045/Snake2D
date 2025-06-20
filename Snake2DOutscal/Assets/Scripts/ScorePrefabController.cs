using UnityEngine;

public class ScorePrefabController : MonoBehaviour
{
    bool isCollected = false;
    public PowerUpController powerUpController;

    private void Start()
    {
        powerUpController = FindFirstObjectByType<PowerUpController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCollected)
        {
            return;
        }
        PlayerController controller = collision.GetComponent<PlayerController>();
        isCollected = true;
        //DoubleScore -- Score Controller
        Debug.Log("gameobject destroyed");
        powerUpController.activePowerUps.Remove(gameObject);
        Destroy(gameObject);
    }
}
