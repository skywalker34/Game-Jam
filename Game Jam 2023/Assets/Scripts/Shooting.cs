using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootInterval = 0.01f;

    private float lastShootTime;

    [Header("Sounds")]
    public AudioSource shoot;

    [Header("ReloadBar")]
    //public int maxBullets = 5;
    public int currentBullets;
    
    public Reload reloadBar;

    private void Start()
    {
        currentBullets = Constants.maxBullets;
        reloadBar.SetMaxShots(Constants.maxBullets);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentBullets > 0)
        {
            Shoot();
            lastShootTime = Time.time;

            Debug.Log(lastShootTime);
        }
    }

    private void FixedUpdate()
    {
        if (Time.time - lastShootTime >= 5 && currentBullets < Constants.maxBullets)
        {
            Reload();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(10,0);

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
