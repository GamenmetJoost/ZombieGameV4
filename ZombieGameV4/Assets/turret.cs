using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet template (should be disabled in the scene)
    public Transform firePoint;     // Where bullets spawn
    public float fireRate = 1f;     // Fire every second

    private float fireCooldown = 0f;

    void Update()
    {
        GameObject closestEnemy = FindClosestEnemy();
        if (closestEnemy != null)
        {
            // Rotate turret to face the closest enemy
            Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Fire bullets at intervals
            fireCooldown -= Time.deltaTime;
            if (fireCooldown <= 0f)
            {
                FireBullet(direction);
                fireCooldown = fireRate; // Reset cooldown
            }
        }
    }

    void FireBullet(Vector3 direction)
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Instantiate a bullet clone
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.SetActive(true); // Ensure the bullet is visible
            Turret_Bullet bulletScript = bullet.GetComponent<Turret_Bullet>();
            bulletScript.isOriginal = false;

            if (bulletScript != null)
            {
                bulletScript.SetDirection(direction);
            }

            Debug.Log("Bullet fired!");
        }
        else
        {
            Debug.LogWarning("BulletPrefab or FirePoint is not assigned!");
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = enemies.Concat(GameObject.FindGameObjectsWithTag("Enemy2")).ToArray();
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }
}
