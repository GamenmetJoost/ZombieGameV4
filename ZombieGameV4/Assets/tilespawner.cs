using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToClone; // Assign multiple objects in the Inspector
    public int numberOfClones = 100;
    public Vector3 spawnArea = new Vector3(10f, 5f, 0f); // Z is typically 0 for 2D
    public string sortingLayerName = "Background"; // Default sorting layer
    public int orderInLayer = -10; // Default order

    public bool spawnAboveEverything = false; // Toggle to spawn on top

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        if (objectsToClone == null || objectsToClone.Length == 0)
        {
            Debug.LogError("No objects assigned to clone!");
            return;
        }

        for (int i = 0; i < numberOfClones; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x),
                Random.Range(-spawnArea.y, spawnArea.y),
                0f
            );

            GameObject randomObject = objectsToClone[Random.Range(0, objectsToClone.Length)];
            GameObject newClone = Instantiate(randomObject, randomPosition, Quaternion.identity);

            // Set sorting layer and order for 2D objects
            SpriteRenderer renderer = newClone.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                if (spawnAboveEverything)
                {
                    renderer.sortingLayerName = "Default"; // Change to whatever topmost layer you use
                    renderer.sortingOrder = 999; // Very high number to ensure it's on top
                }
                else
                {
                    renderer.sortingLayerName = sortingLayerName;
                    renderer.sortingOrder = orderInLayer;
                }
            }
        }
    }
}
