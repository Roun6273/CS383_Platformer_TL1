using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0.0f;

    [SerializeField] float runSpeed = 10.0f;
    [SerializeField] float jumpSpeed = 10.0f;


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

        if (Input.GetButtonDown("Jump")) {
            rb.velocity = new Vector2(0, jumpSpeed);
        }
        AnimUpdate();

    }

    private void AnimUpdate()
    {
        if (dirX > 0f) {
            sprite.flipX = false;
            anim.SetBool("isRunning", true);
        }
        else if (dirX < 0f) {
            sprite.flipX = true;
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }
    }
}
