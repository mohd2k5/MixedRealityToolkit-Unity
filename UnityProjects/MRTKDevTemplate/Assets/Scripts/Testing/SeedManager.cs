using UnityEngine;

namespace MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("MRTK/Examples/Seed Manager")]
    internal class SeedManager : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField, Tooltip("Prefab to spawn when colliding with a 'Seed' tag.")]
        private GameObject collisionSpawnPrefab;

        [Header("Object to Destroy")]
        [SerializeField, Tooltip("The object to destroy upon collision.")]
        private GameObject objectToDestroy;  // Reference to the object that will be destroyed

        private bool hasSpawnedOrDestroyed = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (hasSpawnedOrDestroyed)
                return;

            GameObject other = collision.gameObject;

            if (other.CompareTag("Seed"))
            {
                Debug.Log("SeedManager: Collided with Seed.");

                // Spawn the prefab if assigned
                if (collisionSpawnPrefab != null)
                {
                    Instantiate(collisionSpawnPrefab, transform.position, transform.rotation, null);
                    Debug.Log("SeedManager: Spawned object from collision.");
                }
                else
                {
                    Debug.LogWarning("SeedManager: collisionSpawnPrefab is not assigned.");
                }

                // Destroy the specified object, if it is assigned
                if (objectToDestroy != null)
                {
                    Destroy(objectToDestroy);
                    Debug.Log("SeedManager: Destroyed the specified object.");
                }
                else
                {
                    Debug.LogWarning("SeedManager: objectToDestroy is not assigned.");
                }

                hasSpawnedOrDestroyed = true;
            }
        }
    }
}
