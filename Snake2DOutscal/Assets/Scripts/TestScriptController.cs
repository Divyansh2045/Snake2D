using UnityEngine;

public class TestScriptController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided with TRaingle");
    }
}
