using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player1") == true)
        {
            Debug.Log("Player 1 Damaged!");
        }

        else if (collision.gameObject.tag.Equals("Player2") == true)
        {
            Debug.Log("Player 2 Damaged!");
        }

        Destroy(gameObject);
    }
}
