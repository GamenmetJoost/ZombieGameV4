using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;
    public float shootSpeed = 20.0f;
    public float HP = 100.0f;
    private bool isOriginal = true;
    public GameObject player;
    public float fireRate = 15f;
    private float nextFireTime = 0f;

    void Shoot()
    {
        if (!isOriginal) return;

        GetComponent<SpriteRenderer>().enabled = true;
        transform.position = player.transform.position;

        GameObject clone = Instantiate(gameObject);
        Bullet cloneBullet = clone.GetComponent<Bullet>();
        cloneBullet.isOriginal = false;

        Physics2D.IgnoreCollision(cloneBullet.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), cloneBullet.GetComponent<Collider2D>());

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = ((Vector2)(mouseWorldPos - transform.position)).normalized;

        cloneBullet.horizontal = direction.x;
        cloneBullet.vertical = direction.y;

        transform.position = new Vector2(100000f, 100000f);
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (!isOriginal)
        {
            // Set velocity and rotation only for clones
            body.linearVelocity = new Vector2(horizontal * shootSpeed, vertical * shootSpeed);

            // Calculate rotation angle from velocity
            if (body.linearVelocity != Vector2.zero)
            {
                float angle = Mathf.Atan2(body.linearVelocity.y, body.linearVelocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            Invoke("DestroyBullet", 10.0f);
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + (1f / fireRate);
            Shoot();
        }
    }

    void DestroyBullet() => Destroy(gameObject);

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("base")) Destroy(gameObject);
    }
}