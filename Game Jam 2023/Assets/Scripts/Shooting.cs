using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private PlayerNumber playerNumber;
    public PlayerControl playerControl;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootInterval = 0.01f;

    private float lastShootTime;

    [Header("Sounds")]
    public AudioSource shoot;

    [Header("ReloadBar")]
    public int currentBullets;
    
    public Reload reloadBar;

    private void Start()
    {
        currentBullets = Constants.MAX_BULLET;
        reloadBar.SetMaxShots(Constants.MAX_BULLET);
    }

    void Update()
    {
        if(currentBullets==0) return; 
        if ((Input.GetKeyDown(KeyCode.E)&& playerNumber == PlayerNumber.one) || (Input.GetKeyDown(KeyCode.RightAlt) && playerNumber == PlayerNumber.two))
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    private void FixedUpdate()
    {
        if (Time.time - lastShootTime >= Constants.RELOAD_TIME && currentBullets < Constants.MAX_BULLET)
        {
            Reload();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(playerControl.getDirection()? 10 : -10,0);

        LoseBullets(1);

        shoot.Play();

    }

    void LoseBullets(int bullet)
    {
        currentBullets -= bullet;
    
        reloadBar.SetShots(currentBullets);
    }

    void Reload()
    {
        currentBullets += 1;

        Debug.Log("Current bullets:" + currentBullets);
        reloadBar.SetShots(currentBullets);
    }    
}
