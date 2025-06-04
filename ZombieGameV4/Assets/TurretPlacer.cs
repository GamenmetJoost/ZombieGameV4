using UnityEngine;

public class TurretPlacer : MonoBehaviour
{
    public GameObject turretPrefab; // Assign turret prefab in Inspector
    public Transform player; // Assign the player object in Inspector

    public void PlaceTurret()
    {
        if (turretPrefab != null && player != null)
        {
            turretPrefab turret = turretPrefab.GetComponent<turretPrefab>();
            if (turret == null)
            {
                Debug.LogError("Turret prefab is missing the turretPrefab script!");
                return;
            }

            int cost = turret.Cost;

            if (MaterialManager.Instance.materialAmount >= cost)
            {
                MaterialManager.Instance.materialAmount -= cost;
                Instantiate(turretPrefab, player.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("Not enough materials to place turret.");
            }
        }
        else
        {
            Debug.LogError("Turret prefab or player reference is missing!");
        }
    }
}
