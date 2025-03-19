using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Bullet : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float shootSpeed = 20.0f;
    public float HP = 100.0f;
    private bool isOriginal = true; // Flag to determine the original shooter
    public GameObject player; // Reference to the player object
    public float fireRate = 15f; // 15 shots per second
    private float nextFireTime = 0f;
    void shoot()
{
    if (!isOriginal) return;

    // Make the original bullet invisible by disabling its renderer

    transform.position = player.transform.position;

    // Instantiate a clone and get its Bullet component
    GameObject clone = Instantiate(gameObject);
    Bullet cloneBullet = clone.GetComponent<Bullet>();
    GetComponent<SpriteRenderer>().enabled = true;

    // Set the clone's isOriginal to false
    cloneBullet.isOriginal = false;

    // Ignore collision between the bullet (original) and player
    Physics2D.IgnoreCollision(cloneBullet.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

    // Also ignore collision between the original bullet and player
    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

    // Ignore collision between the original and clone bullet
    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), cloneBullet.GetComponent<Collider2D>());

    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    // Convert to 2D by ignoring the Z-axis
    Vector2 mousePos2D = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
    Vector2 objectPos2D = new Vector2(transform.position.x, transform.position.y);

    // Calculate the direction vector
    Vector2 direction = (mousePos2D - objectPos2D).normalized;

    // Debugging (Shows the direction in the console)
    cloneBullet.horizontal = direction.x;
    cloneBullet.vertical = direction.y;

    transform.position = new Vector2(100000f, 100000f);

    }


    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (!isOriginal)
        Invoke("DestroyBullet", 10.0f);
        body.linearVelocity = new Vector2(horizontal * shootSpeed, vertical * shootSpeed);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + (1f / fireRate);
            shoot();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("base"))
        {

                Destroy(gameObject);
            
        }
    }
}
