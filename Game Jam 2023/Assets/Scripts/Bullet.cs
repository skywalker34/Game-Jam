using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player1") == true)
        {
            SceneManager.LoadScene((int)Scene.GameOverP1);
        }
        else if (collision.gameObject.tag.Equals("Player2") == true)
        {
            SceneManager.LoadScene((int)Scene.GameOverP2);
        }

        Destroy(gameObject);
    }
}
