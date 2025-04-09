using UnityEngine;


public class TurretPlacer : MonoBehaviour
{
    public GameObject turretPrefab; // Assign the turret prefab in Inspector
    public Transform player; // Assign the player object in Inspector

    public void PlaceTurret()
    {
        if (turretPrefab != null && player != null)
        {
            if (MaterialManager.Instance.materialAmount >= 10) 
            {
                MaterialManager.Instance.materialAmount -= 10;
                Instantiate(turretPrefab, player.position + new Vector3(160, 120, 0), Quaternion.identity);
            }
        }
        else
        {
            Debug.LogError("Turret prefab or player reference is missing!");
        }
    }
}
