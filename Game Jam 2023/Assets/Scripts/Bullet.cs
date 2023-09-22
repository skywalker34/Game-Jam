using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public int p1HP = 5;
    public int p2HP = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player1") == true)
        {
            Debug.Log("Player 1 Damaged!");
            SceneManager.LoadScene(3);
        }

        else if (collision.gameObject.tag.Equals("Player2") == true)
        {
            Debug.Log("Player 2 Damaged!");
            SceneManager.LoadScene(4);
        }

        Destroy(gameObject);
    }
}
