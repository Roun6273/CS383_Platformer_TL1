using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public float speed = 10.0f;
    [SerializeField] KeyCode keyLeft = KeyCode.A;
    [SerializeField] KeyCode keyRight = KeyCode.D;
    [SerializeField] KeyCode keyDown = KeyCode.S;
    [SerializeField] KeyCode keyJump = KeyCode.W;


    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(keyLeft))
            direction = Vector2.left;
        else if (Input.GetKey(keyRight))
            direction = Vector2.right;
        else if (Input.GetKey(keyDown))
            direction = Vector2.down;
        else if (Input.GetKeyDown(keyJump))
            direction = Vector2.up;
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}
