using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Drag your player here in the inspector
    public float smoothSpeed = 5f; // Adjust for smooth following

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
