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
            SceneManager.LoadScene(4);
        }

        else if (collision.gameObject.tag.Equals("Player2") == true)
        {
            SceneManager.LoadScene(3);
        }

        Destroy(gameObject);
    }
}
