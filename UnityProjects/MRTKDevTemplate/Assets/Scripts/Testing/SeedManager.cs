using UnityEngine;
using UnityEngine.UI;

namespace MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("MRTK/Examples/Seed Manager")]
    internal class SeedManager : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField, Tooltip("Prefab to spawn when colliding with a 'Seed' tag.")]
        private GameObject collisionSpawnPrefab;

        [SerializeField, Tooltip("Prefab to spawn when clicking the button.")]
        private GameObject buttonSpawnPrefab;

        private bool hasSpawnedOrDestroyed = false;

        private Vector3 initialPosition;
        private Quaternion initialRotation;
        private Transform initialParent;

        private void Awake()
        {
            initialPosition = transform.position;
            initialRotation = transform.rotation;
            initialParent = transform.parent;
        }

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

        // ✅ Button method: spawn different object at original position
        public void SpawnAtStartTransform()
        {
            if (buttonSpawnPrefab != null)
            {
                Instantiate(buttonSpawnPrefab, initialPosition, initialRotation, initialParent);
                Debug.Log("SeedManager: Spawned button object at initial position.");
            }
            else
            {
                Debug.LogWarning("SeedManager: buttonSpawnPrefab is not assigned.");
            }
        }
    }
}
