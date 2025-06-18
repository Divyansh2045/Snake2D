using UnityEngine;

public class SnakeBodyController : MonoBehaviour
{
    public PlayerController playerController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();

            Debug.Log("Player collided with its own body and Player died");
              PlayerController.PlayerDie();
            //Show game over UI
        }



    }
}
