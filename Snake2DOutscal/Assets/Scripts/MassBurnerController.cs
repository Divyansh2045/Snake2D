using UnityEngine;

public class MassBurnerController : MonoBehaviour
{
    private bool isCollected = false;
    public GameManagerController gameManagerController;

    private void Start()
    {
        gameManagerController = FindFirstObjectByType<GameManagerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCollected)
        {
            Debug.Log(" is collected is true");
            return;
        }
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            isCollected = true;
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.massBurner();
            gameManagerController.massBurner.Remove(gameObject);
            Debug.Log(" massBurner status: " + isCollected);
            Destroy(gameObject);

        }
    }
}
