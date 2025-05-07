using UnityEngine;

public class Turret_Bullet : MonoBehaviour
{
    public float speed = 40f;
    public float lifetime = 5f;
    public float spreadAngle = 5f; // Max deviation in degrees
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

        // Apply spread
        float randomSpread = Random.Range(-spreadAngle, spreadAngle);
        direction = Quaternion.Euler(0, 0, randomSpread) * direction.normalized;

        rb.linearVelocity = direction * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
