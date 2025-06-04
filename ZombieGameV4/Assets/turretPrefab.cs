using UnityEngine;

public class turretPrefab : MonoBehaviour
{
    [SerializeField]
    private int cost; // Set this in the Inspector

    public int Cost => cost; // Optional: public getter if needed
}
