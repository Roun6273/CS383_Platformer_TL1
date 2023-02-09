using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0.0f;
    private int jumpCount = 0;

    [SerializeField] private float runSpeed = 10.0f;
    [SerializeField] private float jumpSpeed = 10.0f;

    private enum AnimMovement {
        idling,
        running,
        jumping,
        double_jumping,
        falling,
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && jumpCount < 2) {
            rb.velocity = new Vector2(0, jumpSpeed);
            jumpCount++;
        }
        AnimUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision detected");
        jumpCount = 0;
    }

    private void AnimUpdate()
    {
        AnimMovement state;

        // running, idling animation check
        if (dirX > 0f) {
            state = AnimMovement.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f) {
            state = AnimMovement.running;
            sprite.flipX = true;
        }
        else {
            state = AnimMovement.idling;
        }

        // jumping, double jumping, falling animation check
        if (rb.velocity.y > 0.1f && jumpCount == 1) {
            state = AnimMovement.jumping;
        }
        else if (rb.velocity.y > 0.1f && jumpCount == 2) {
            state = AnimMovement.double_jumping;
        }
        else if (rb.velocity.y < -0.1f) {
            state = AnimMovement.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
