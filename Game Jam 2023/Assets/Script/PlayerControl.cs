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

    Vector2 velocity;
    int gravityScale = 1;
    bool isGrounded;
    bool isRoof;
    bool isForwardDirection;

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

        switch (getUserInput())
        {
            case Movement.right:
                {
                    isForwardDirection = true;
                    playerRigidbody.velocity = new Vector2(Constants.horixontalSpeed, playerRigidbody.velocity.y);
                    break;
                }
            case Movement.left:
                {
                    isForwardDirection = false;
                    playerRigidbody.velocity = new Vector2(-Constants.horixontalSpeed, playerRigidbody.velocity.y);
                    break;
                }
            case Movement.up:
                {
                    gravityScale = isGrounded ? 1 : -1;
                    playerRigidbody.gravityScale = gravityScale;
                    playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Constants.verticalSpeed);
                    break;
                }
            case Movement.down:
                {
                    gravityScale = isRoof ? -1 : 1;
                    playerRigidbody.gravityScale = gravityScale;
                    playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, -Constants.verticalSpeed);
                    break;
                }
            case Movement.dash:
                {
                    playerRigidbody.gravityScale = isGrounded ? playerRigidbody.gravityScale : 0;
                    playerRigidbody.velocity = new Vector2(isForwardDirection ? Constants.dashingSpeed : -Constants.dashingSpeed, 0);
                    break;
                }
        }

        if (playerRigidbody.gravityScale == 0 && Math.Abs(playerRigidbody.velocity.x) < Constants.horixontalSpeed)
        {
            playerRigidbody.gravityScale = gravityScale;
        }
    }

    Movement getUserInput()
    {
        if ((playerNumber == PlayerNumber.one && Input.GetKey(KeyCode.D)) || (playerNumber == PlayerNumber.two && Input.GetKey(KeyCode.RightArrow)))
        {
            return Movement.right;
        }
        else if ((playerNumber == PlayerNumber.one && Input.GetKey(KeyCode.A)) || (playerNumber == PlayerNumber.two && Input.GetKey(KeyCode.LeftArrow)))
        {
            return Movement.left;
        }
        else if ((playerNumber == PlayerNumber.one && Input.GetKeyDown(KeyCode.W)) || (playerNumber == PlayerNumber.two && Input.GetKeyDown(KeyCode.UpArrow)))
        {
            return Movement.up;
        }
        else if ((playerNumber == PlayerNumber.one && Input.GetKeyDown(KeyCode.S)) || (playerNumber == PlayerNumber.two && Input.GetKeyDown(KeyCode.DownArrow)))
        {
            return Movement.down;
        }
        else if ((playerNumber == PlayerNumber.one && Input.GetKeyDown(KeyCode.Q)) || (playerNumber == PlayerNumber.two && Input.GetKeyDown(KeyCode.RightControl)))
        {
            return Movement.dash;
        }
        else
        {
            return Movement.stop;
        }
    }
}
