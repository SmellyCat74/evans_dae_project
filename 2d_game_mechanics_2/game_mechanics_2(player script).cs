using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private int jumpCount = 0;
    public int maxJumps = 2; // Allows double jump

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount < maxJumps))
        {
            Jump();
        }
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpCount++;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 contactPoint = collision.contacts[0].point;
            Vector2 center = collision.collider.bounds.center;

            // Stomp detection
            if (transform.position.y > center.y + 0.3f)
            {
                Debug.Log("Enemy Stomped!");
                collision.gameObject.GetComponent<EnemyAI>().Die();

                // Bounce effect after stomp
                rb.velocity = new Vector2(rb.velocity.x, jumpForce / 1.5f);
            }
            else
            {
                Debug.Log("Player takes damage!");
            }
        }
    }
}
