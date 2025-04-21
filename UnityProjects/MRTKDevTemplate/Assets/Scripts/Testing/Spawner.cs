using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Tooltip("Prefab to spawn when the button is pressed.")]
    private GameObject prefabToSpawn;

    [SerializeField, Tooltip("Transform where the prefab will be spawned.")]
    private Transform spawnLocation;

    // ✅ Call this from a UI button
    public void SpawnAtTargetTransform()
    {
        if (prefabToSpawn == null)
        {
            Debug.LogWarning("Spawner: prefabToSpawn is not assigned.");
            return;
        }

        if (spawnLocation == null)
        {
            Debug.LogWarning("Spawner: spawnLocation is not assigned.");
            return;
        }

        Instantiate(prefabToSpawn, spawnLocation.position, spawnLocation.rotation, spawnLocation.parent);
        Debug.Log("Spawner: Spawned prefab at target transform.");
    }
}

