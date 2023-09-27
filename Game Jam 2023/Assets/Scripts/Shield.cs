using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private PlayerNumber playerNumber;
    public string targetTag = "Bullet";
    public int playerOneShield = 3;
    public int playerTwoShield = 3;

    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D bullet)
    {
        if (bullet.gameObject.tag.Equals(targetTag)) {
            HitByBullet();
        }
    }

    void HitByBullet()
    {
        if(playerNumber == PlayerNumber.One && playerOneShield > 0)
        {
            playerOneShield--;
        }
        else if (playerNumber == PlayerNumber.Two && playerTwoShield > 0)
        {
            playerTwoShield--;
        }
        gameObject.SetActive(false);
    }
}
