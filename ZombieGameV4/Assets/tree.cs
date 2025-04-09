using UnityEngine;

public class tree : MonoBehaviour
{
    private Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Destroy the bullet
            Destroy(gameObject); // Destroy the tree

            MaterialManager.Instance.materialAmount += 2; // Add materials to the player
        }
    }
}
