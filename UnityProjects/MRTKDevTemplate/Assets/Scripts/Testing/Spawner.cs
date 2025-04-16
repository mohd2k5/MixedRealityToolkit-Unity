using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnLocation;
    public float spawnRadius = 0.5f;
    public bool useRandomYRotation = false;

    public void SpawnNewObject()
    {
        if (objectToSpawn == null || spawnLocation == null)
        {
            Debug.LogError("Spawner: Missing references.");
            return;
        }

        Vector3 targetPosition = spawnLocation.position;

        if (!IsSpawnLocationClear(targetPosition))
        {
            targetPosition = FindClearPosition(targetPosition);
        }

        Quaternion rotation = useRandomYRotation
            ? Quaternion.Euler(0, Random.Range(0f, 360f), 0)
            : spawnLocation.rotation;

        Instantiate(objectToSpawn, targetPosition, rotation);
    }

    private bool IsSpawnLocationClear(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, spawnRadius);
        return colliders.Length == 0;
    }

    private Vector3 FindClearPosition(Vector3 position)
    {
        const int maxAttempts = 10;
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            Vector3 newPos = position + offset;
            if (IsSpawnLocationClear(newPos))
            {
                return newPos;
            }
        }

        return position;
    }

    private void OnDrawGizmosSelected()
    {
        if (spawnLocation != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(spawnLocation.position, spawnRadius);
        }
    }
}
