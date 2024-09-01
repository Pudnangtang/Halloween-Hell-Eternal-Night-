using UnityEngine;

public class CandyCornBullet : MonoBehaviour
{
    public float speed = 10f; // Bullet speed
    public float lifeTime = 5f; // Time before bullet is destroyed
    public int damage = 1; // Damage dealt to enemies

    private Vector2 direction;

    void Start()
    {
        // Destroy the bullet after lifeTime seconds to prevent memory leaks
        Destroy(gameObject, lifeTime);
    }

    public void Initialize(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        // Move the bullet in the direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Handle collision with enemies
        // Example: if the bullet hits an enemy, deal damage
        // Assuming enemies have a script with a TakeDamage method
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        // Optionally, destroy the bullet on hitting any obstacle
        // else if (other.CompareTag("Obstacle"))
        // {
        //     Destroy(gameObject);
        // }
    }
}
