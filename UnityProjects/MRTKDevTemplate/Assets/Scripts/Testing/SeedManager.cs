using UnityEngine;

namespace MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("MRTK/Examples/Seed Manager")]
    internal class SeedManager : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField, Tooltip("Prefab to spawn when colliding with a 'Seed' tag.")]
        private GameObject collisionSpawnPrefab;

        private bool hasSpawnedOrDestroyed = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (hasSpawnedOrDestroyed)
                return;

            GameObject other = collision.gameObject;

            if (other.CompareTag("Seed"))
            {
                Debug.Log("SeedManager: Collided with Seed.");

                if (collisionSpawnPrefab != null)
                {
                    Instantiate(collisionSpawnPrefab, transform.position, transform.rotation, transform.parent);
                    Debug.Log("SeedManager: Spawned object from collision.");
                }
                else
                {
                    Debug.LogWarning("SeedManager: collisionSpawnPrefab is not assigned.");
                }

                hasSpawnedOrDestroyed = true;
                Destroy(gameObject);
            }
        }

        public void DestroySelf()
        {
            if (hasSpawnedOrDestroyed) return;

            Debug.Log("SeedManager: Destroy button pressed.");
            hasSpawnedOrDestroyed = true;
            Destroy(gameObject);
        }
    }
}
