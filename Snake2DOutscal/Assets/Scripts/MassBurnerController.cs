using UnityEngine;

public class MassBurnerController : MonoBehaviour
{
    private bool isCollected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (isCollected == true)
        {
            Debug.Log(" is collected is true");
            return;
        }
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            isCollected = true;
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.massBurner();
            Destroy(gameObject);

        }
    }
}
