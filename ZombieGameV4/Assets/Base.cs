using Unity.VisualScripting;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float HP = 100.0f;
    private Rigidbody2D body;

    // Sleep dit GameObject in de inspector
    public GameObject gameOverScreen;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(HP);

        if (collision.CompareTag("Enemy"))
        {
            // Reduce HP when hit by an enemy
            HP -= 10f;
        }
        if (collision.CompareTag("Enemy2"))
        {
            // Reduce HP when hit by an enemy2
            HP -= 5f;

            // Destroy the bullet on impact
            Destroy(collision.gameObject);
        }

        // Check if HP is depleted
        if (HP <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (gameOverScreen != null)
        {
            var screen = gameOverScreen.GetComponent<GameOverScreen>();
            if (screen != null)
            {
                screen.Show();
            }
            else
            {
                gameOverScreen.SetActive(true);
            }
        }
        Time.timeScale = 0f; // Pauzeer het spel
        Destroy(gameObject);
    }

    // Public method to trigger GameOver from other scripts
    public void TriggerGameOver()
    {
        GameOver();
    }

    void OnGUI()
    {
        // Set the style for the text
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        style.normal.textColor = Color.red;

        // Display the HP in bright red letters
        GUI.Label(new Rect(10, 10, 200, 50), "HP: " + HP.ToString("F1"), style);
        // Set the style for the text
        style.fontSize = 24;
        style.normal.textColor = Color.green;
        // Get the material amount from the MaterialManager instance
        int materialAmount = MaterialManager.Instance.materialAmount; // Assuming you have a MaterialManager script managing the materials
        GUI.Label(new Rect(10, 35, 200, 50), "Materials: " + materialAmount.ToString("F1"), style);

    }
}