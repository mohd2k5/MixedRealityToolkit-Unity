using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;  // The object to spawn (assign in Inspector)
    public Transform spawnLocation;   // The location on the table to spawn the new object (assign in Inspector)
    public float spawnRadius = 0.5f;  // Radius to check for overlapping objects (adjust as necessary)

    private bool isObjectMoved = false;

    void Start()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("Object to spawn is not assigned.");
        }
    }

    void Update()
    {
        // This is where we would check for user input or manipulation in a non-MRTK setup
        // For this example, we're simulating a simple condition to trigger spawning.
        if (isObjectMoved == false && Input.GetKeyDown(KeyCode.Space)) // Simulate triggering spawn with Space key
        {
            SpawnNewObject();
            isObjectMoved = true;  // Ensure it only spawns once
        }
    }

    // Method to spawn the new object on the table
    private void SpawnNewObject()
    {
        if (objectToSpawn != null && spawnLocation != null)
        {
            // Check if the spawn location is clear (no overlapping objects)
            if (IsSpawnLocationClear(spawnLocation.position))
            {
                // Instantiate a new object at the spawn location
                Instantiate(objectToSpawn, spawnLocation.position, spawnLocation.rotation);
            }
            else
            {
                Debug.Log("Spawn location is occupied, trying a different spot.");
                // Optionally, adjust the spawn position slightly if it's occupied
                Vector3 adjustedPosition = FindClearPosition(spawnLocation.position);
                Instantiate(objectToSpawn, adjustedPosition, spawnLocation.rotation);
            }
        }
    }

    // Method to check if the spawn location is clear (no colliders in the area)
    private bool IsSpawnLocationClear(Vector3 position)
    {
        // Use Physics.OverlapSphere to check for existing colliders in the spawn area
        Collider[] colliders = Physics.OverlapSphere(position, spawnRadius);
        return colliders.Length == 0;  // No colliders means the area is clear
    }

    // Method to find a new clear spawn position nearby
    private Vector3 FindClearPosition(Vector3 position)
    {
        Vector3 offset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));  // Random offset
        Vector3 newPosition = position + offset;

        // Check again if the new position is clear
        while (!IsSpawnLocationClear(newPosition))
        {
            offset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            newPosition = position + offset;
        }

        return newPosition;
    }
}
