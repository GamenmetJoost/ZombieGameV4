using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{
    public GameObject goal; // Assign the goal in Unity Inspector
    public float moveSpeed = 5.0f;
    public float Reduction = 0f;

    public float shootSpeed = 20.0f;
    public float HP = 100.0f;
    public float SpawnChance = 50;
    public float increaseOnSpawn = 0.01f;
    private bool isOriginal = true;
    private Rigidbody2D body;
    private System.Random random = new System.Random();

    public float minSpawnRange = 0f; // Minimum distance from the center (zet op 100 binnen Unity)
    public float maxSpawnRange = 0f; // Maximum distance from the center (zet op 200 binnen Unity)

    void OnValidate()
    {
        // Ensure minSpawnRange is not greater than maxSpawnRange
        if (minSpawnRange > maxSpawnRange)
        {
            minSpawnRange = maxSpawnRange;
        }
    }


    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        // Set enemy at a random position within a range
        float randomX = UnityEngine.Random.Range(-maxSpawnRange, maxSpawnRange);
        float randomY = UnityEngine.Random.Range(-maxSpawnRange, maxSpawnRange);
        transform.position = new Vector2(randomX, randomY);
    }

    void FixedUpdate()
    {
        if (goal != null)
        {
            // Move towards the goal
            Vector2 direction = (goal.transform.position - transform.position).normalized;
            body.linearVelocity = direction * moveSpeed;
            Vector3 directionToGoal = (goal.transform.position - transform.position).normalized;
            transform.right = directionToGoal;
        }

        if (isOriginal)
        {
            transform.position = new Vector2(2000f, 1000f);


            int randomNumber = random.Next(0, (int)Mathf.Floor(SpawnChance));
            if (randomNumber == 0)
            {
                SpawnChance -= increaseOnSpawn;
                GameObject clone = Instantiate(gameObject);
                Enemy cloneEnemy = clone.GetComponent<Enemy>();
                cloneEnemy.isOriginal = false;
                cloneEnemy.goal = this.goal; // Assign goal to the clone
            }
        }
    }

    static float DamageReduction(float Damage, float Reduction)
    {
        Damage = Damage - Reduction;
        if (Damage < 0)
        {
            Damage = 0;
        }
        return Damage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bullet"))
        {
            // Reduce HP when hit by a bullet
            HP -= DamageReduction(40, Reduction);

            // Destroy the bullet on impact
            Destroy(collision.gameObject);
            // Check if HP is depleted

        }
        if (collision.CompareTag("Turret2Bullet"))
        {
            // Reduce HP when hit by a bullet
            HP -= DamageReduction(100, Reduction);

            // Destroy the bullet on impact
            Destroy(collision.gameObject);
            // Check if HP is depleted

        }
        if (collision.CompareTag("Turret1Bullet"))
        {
            // Reduce HP when hit by a bullet
            HP -= DamageReduction(40, Reduction);

            // Destroy the bullet on impact
            Destroy(collision.gameObject);
            // Check if HP is depleted

        }
        if (collision.CompareTag("TurretMinigunBullet"))
        {
            // Reduce HP when hit by a bullet
            HP -= DamageReduction(10, Reduction);

            // Destroy the bullet on impact
            Destroy(collision.gameObject);
            // Check if HP is depleted

        }
        if (collision.CompareTag("FlameBullet"))
        {
            // Reduce HP when hit by a bullet
            HP -= DamageReduction(6, Reduction);

            // Destroy the bullet on impact
            Destroy(collision.gameObject);
            // Check if HP is depleted

        }
        if (collision.CompareTag("base"))
        {
            // Reduce HP when hit by a bullet
            HP -= 50.0f;

            // Check if HP is depleted
        }

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
