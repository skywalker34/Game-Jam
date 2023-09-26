using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private PlayerNumber playerNumber;
    [SerializeField] private ShootingDirection shootingDirection;
    public PlayerControl playerControl;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
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
        UpdateShootingPoint();
        if (currentBullets==0) return; 
        if ((Input.GetKeyDown(KeyCode.E)&& playerNumber == PlayerNumber.One) || (Input.GetKeyDown(KeyCode.RightAlt) && playerNumber == PlayerNumber.Two))
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

    void UpdateShootingPoint()
    {
        
    }

    void Shoot()
    {
        if(shootingDirection==ShootingDirection.Forward && !playerControl.getDirection())
        {
            return;
        }
        if (shootingDirection == ShootingDirection.Backward && playerControl.getDirection())
        {
            return;
        }
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(playerControl.getDirection()? 10 : -10,0);

        LoseBullets();

        shoot.Play();

    }

    void LoseBullets()
    {
        currentBullets--;
    
        reloadBar.SetShots(currentBullets);
    }

    void Reload()
    {
        currentBullets++;
        reloadBar.SetShots(currentBullets);
    }    
}
