using UnityEngine;

public class SnakeBodyController : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("SnakebodyController is active");
    }
    public PlayerController playerController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision function is entered");
     
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();

            Debug.Log("Player collided with its own body and Player died");
            Destroy(collision.gameObject);  //PlayerController.Die();
            //Show game over UI
        }



    }
}
