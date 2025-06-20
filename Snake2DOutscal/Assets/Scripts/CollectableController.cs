using UnityEngine;

public class CollectableController : MonoBehaviour
{
    PlayerController playerController;
    GameManagerController gameManagerController;
    private bool isCollected = false;

    private void Start()
    {
        gameManagerController = FindFirstObjectByType<GameManagerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCollected)
        {
            return;
        }

            if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            isCollected = true;
            playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.growSnake();
            Debug.Log("First touch");
            gameManagerController.fruits.Remove(gameObject);
            Destroy(gameObject);
            Debug.Log(" fruit status: " + isCollected);

        }
    }
}
     
    

