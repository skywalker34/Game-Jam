using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerNumber playerNumber;
    public Rigidbody2D playerRigidbody;
    public Transform groundCheck;
    public Transform roofCheck;
    public LayerMask groundLayer;
    public LayerMask roofLayer;
    public SpriteRenderer spriteRenderer;

    Vector2 velocity;
    int gravityScale = 1;
    bool isGrounded;
    bool isRoof;
    bool isForwardDirection;

    [Header("Sounds")]
    public AudioSource jump, dash;

    // Start is called before the first frame update
    void Start()
    {
        isForwardDirection = playerNumber == PlayerNumber.one;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        isRoof = Physics2D.OverlapCircle(roofCheck.position, 0.1f, roofLayer);

        SetVerticalVelocity();
        SetMovement();
        ResetGravityScale();
    }

    void SetVerticalVelocity()
    {
        if (isGrounded && velocity.y <= 0)
        {
            velocity.y = 0;
        }
        else if (isRoof && velocity.y >= 0)
        {
            velocity.y = 0;
        }
        else if (playerRigidbody.gravityScale == 1)
        {
            velocity.y += Constants.gravity * Time.deltaTime;
            playerRigidbody.AddForce(new Vector2(0, velocity.y));
        }
        else if (playerRigidbody.gravityScale == -1)
        {
            velocity.y += -Constants.gravity * Time.deltaTime;
            playerRigidbody.AddForce(new Vector2(0, velocity.y));
        }
    }

    void SetMovement()
    {
        if ((playerNumber == PlayerNumber.one && Input.GetKey(KeyCode.D)) || (playerNumber == PlayerNumber.two && Input.GetKey(KeyCode.RightArrow)))
        {
            isForwardDirection = true;
            playerRigidbody.velocity = new Vector2(GetHorizontalSpeed(), playerRigidbody.velocity.y);
        }
        if ((playerNumber == PlayerNumber.one && Input.GetKey(KeyCode.A)) || (playerNumber == PlayerNumber.two && Input.GetKey(KeyCode.LeftArrow)))
        {
            isForwardDirection = false;
            playerRigidbody.velocity = new Vector2(-GetHorizontalSpeed(), playerRigidbody.velocity.y);
        }
        if ((playerNumber == PlayerNumber.one && Input.GetKeyDown(KeyCode.W)) || (playerNumber == PlayerNumber.two && Input.GetKeyDown(KeyCode.UpArrow)))
        {
            gravityScale = isGrounded ? 1 : -1;
            spriteRenderer.flipY = !isGrounded;
            playerRigidbody.gravityScale = gravityScale;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Constants.verticalSpeed);
            jump.Play();
        }
        if ((playerNumber == PlayerNumber.one && Input.GetKeyDown(KeyCode.S)) || (playerNumber == PlayerNumber.two && Input.GetKeyDown(KeyCode.DownArrow)))
        {
            gravityScale = isRoof ? -1 : 1;
            spriteRenderer.flipY = isRoof;
            playerRigidbody.gravityScale = gravityScale;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, -Constants.verticalSpeed);
            jump.Play();
        }
        if ((playerNumber == PlayerNumber.one && Input.GetKeyDown(KeyCode.Q)) || (playerNumber == PlayerNumber.two && Input.GetKeyDown(KeyCode.RightControl)))
        {
            playerRigidbody.gravityScale = isGrounded ? playerRigidbody.gravityScale : 0;
            playerRigidbody.velocity = new Vector2(isForwardDirection ? Constants.dashingSpeed : -Constants.dashingSpeed, 0);
            dash.Play();
        }
    }

    float GetHorizontalSpeed()
    {
        return Math.Abs(playerRigidbody.velocity.x) > Constants.horixontalSpeed ? Math.Abs(playerRigidbody.velocity.x) : Constants.horixontalSpeed;
    }

    void ResetGravityScale() {
        if (playerRigidbody.gravityScale == 0 && Math.Abs(playerRigidbody.velocity.x) < Constants.horixontalSpeed)
        {
            playerRigidbody.gravityScale = gravityScale;
        }
    }
}
