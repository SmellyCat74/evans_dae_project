using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public int health = 10;
    public GameObject enemyPrefab;
    public float spawnOffset = 1.5f;

    private Transform player;
    private Rigidbody2D rb;
    private bool isChasing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        isChasing = distanceToPlayer < detectionRange;

        if (isChasing)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy defeated!");

        // Spawn two new enemies
        Instantiate(enemyPrefab, transform.position + new Vector3(spawnOffset, 0, 0), Quaternion.identity);
        Instantiate(enemyPrefab, transform.position + new Vector3(-spawnOffset, 0, 0), Quaternion.identity);

        Destroy(gameObject);
    }
}
