using UnityEngine;

public class Base : MonoBehaviour
{


    public float HP = 100.0f;
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
        Debug.Log(HP);

        if (collision.CompareTag("Enemy"))
        {
            // Reduce HP when hit by a bullet
            HP -= 5f;

            // Destroy the bullet on impact
            Destroy(collision.gameObject);
            // Check if HP is depleted
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
