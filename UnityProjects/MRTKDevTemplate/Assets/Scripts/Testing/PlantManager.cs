using UnityEngine;

namespace MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("MRTK/Examples/Plant Manager")]
    internal class PlantManager : MonoBehaviour
    {
        [SerializeField, Tooltip("Prefab to spawn when colliding with a 'Water' tag.")]
        private GameObject objectToSpawn;

        private bool hasSpawnedOrDestroyed = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (hasSpawnedOrDestroyed)
                return;

            GameObject other = collision.gameObject;
            string tag = other.tag;

            if (tag == "Water")
            {
                Debug.Log("PlantManager: Collided with Water.");

                if (objectToSpawn != null)
                {
                    Instantiate(objectToSpawn, transform.position, transform.rotation, transform.parent);
                    Debug.Log("PlantManager: Spawned new object.");
                }
                else
                {
                    Debug.LogWarning("PlantManager: objectToSpawn is not assigned.");
                }

                hasSpawnedOrDestroyed = true;
                Destroy(gameObject);
            }
            
            if (collision.gameObject.CompareTag("Trash"))
            {
                Destroy(gameObject);
            }
        }
    }
}
