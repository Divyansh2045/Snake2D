using UnityEngine;

public class CollectableController : MonoBehaviour
{
    PlayerController playerController;
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.growSnake();
            Destroy(gameObject);

        }
    }
}
     
    

