using UnityEngine;

public class TurretPlacer : MonoBehaviour
{
    public GameObject turretPrefab; // Assign the turret prefab in Inspector
    public Transform player; // Assign the player object in Inspector

    public void PlaceTurret()
    {
        if (turretPrefab != null && player != null)
        {
            Debug.Log(player.position.ToString());
            Instantiate(turretPrefab, player.position, Quaternion.identity);
            Debug.Log("Turret placed at player's position!");
        }
        else
        {
            Debug.LogError("Turret prefab or player reference is missing!");
        }
    }
}
