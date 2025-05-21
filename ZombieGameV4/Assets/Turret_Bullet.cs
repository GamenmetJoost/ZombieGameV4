using UnityEngine;

public class Turret_Bullet : MonoBehaviour
{
    public float speed = 40f;
    public float lifetime = 5f;
    public float spreadAngle = 5f; // Standard deviation in degrees for bell curve
    public bool isOriginal = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!isOriginal)
        {
            Destroy(gameObject, lifetime);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        // Normalize direction
        direction = direction.normalized;

        // Apply bell curve (Gaussian) spread
        float randomSpread = RandomGaussian() * spreadAngle;
        direction = Quaternion.Euler(0, 0, randomSpread) * direction;

        // Set velocity and rotation
        rb.linearVelocity = direction * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Box-Muller transform to generate Gaussian distributed values
    private float RandomGaussian()
    {
        float u1 = 1.0f - Random.value; // Avoid 0
        float u2 = 1.0f - Random.value;
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
        return randStdNormal; // Mean 0, StdDev 1
    }
}
